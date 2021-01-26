using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SSEA.BL.Models.Auth;
using SSEA.BL.Services.Interfaces;
using SSEA.DAL.Entities.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.BL.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private UserManager<User> userManager;
        private IConfiguration configuration;

        public AuthService(UserManager<User> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<AuthResponseModel> RegisterUserAsync(RegisterUserModel model)
        {
            if (model == null)
                throw new NullReferenceException("Register model is null!");

            if (model.Password != model.ConfirmPassword)
            {
                return new AuthResponseModel()
                {
                    Message = "Confirm password doesn't match the password",
                    IsSuccess = false,
                };
            }

            var newUser = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.FirstName + " " + model.LastName,
            };

            var result = await userManager.CreateAsync(newUser, model.Password);
            if (result.Succeeded)
            {
                return new AuthResponseModel()
                {
                    Message = "User created susuccessfully!",
                    IsSuccess = true,
                };
            }

            return new AuthResponseModel()
            {
                Message = "User did not create",
                IsSuccess = false,
                Errors = result.Errors.Select(error => error.Description),
            };
        }

        public async Task<AuthResponseModel> LoginUserAsync(LoginUserModel model)
        {
            if (model == null)
                throw new NullReferenceException("Login model is null!");

            User user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new AuthResponseModel()
                {
                    Message = "There is no user with that email address",
                    IsSuccess = false,
                };
            }

            bool validPassword = await userManager.CheckPasswordAsync(user, model.Password);
            if (!validPassword)
            {
                return new AuthResponseModel()
                {
                    Message = "Invalid password",
                    IsSuccess = false,
                };
            }

            var claims = new Claim[]
            {
                new Claim("Email", model.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(issuer: configuration["AuthSettings:Issuer"],
                                             audience: configuration["AuthSettings:Audience"],
                                             claims: claims,
                                             expires: DateTime.Now.AddHours(1),
                                             signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
            
            return new AuthResponseModel()
            {
                Message = tokenAsString,
                IsSuccess = true,
                ExpireDate = token.ValidTo,
            };
        }
    }
}
