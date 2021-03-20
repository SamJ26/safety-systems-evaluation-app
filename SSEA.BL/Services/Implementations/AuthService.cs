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
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;

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

            // TODO: assigning initial active state to new user

            var newUser = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
            };

            var result = await userManager.CreateAsync(newUser, model.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(newUser, "Observer");
                return new AuthResponseModel()
                {
                    Message = "User created susuccessfully!",
                    IsSuccess = true,
                };
            }

            return new AuthResponseModel()
            {
                Message = "Failed to create a new user",
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

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:SecurityKey"]));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claimsArray = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim("Email", model.Email),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
            };

            var claims = new List<Claim>();
            claims.AddRange(claimsArray);
            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenOptions = new JwtSecurityToken(issuer: configuration["JWTSettings:ValidIssuer"],
                                                    audience: configuration["JWTSettings:ValidAudience"],
                                                    claims: claims,
                                                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(configuration["JWTSettings:ExpiryInMinutes"])),
                                                    signingCredentials: signingCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            
            return new AuthResponseModel()
            {
                Token = token,
                Message = "Everything is ok",
                IsSuccess = true,
            };
        }
    }
}
