using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SSEA.BL.Services.Implementations;
using SSEA.BL.Services.Interfaces;
using SSEA.DAL;
using Microsoft.AspNetCore.Identity;
using SSEA.DAL.Entities.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SSEA.BL.Facades;
using SSEA.BL.Models;
using SSEA.DAL.Repositories;

namespace SSEA.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddDefaultPolicy(config => config.AllowAnyHeader()
                                                                                 .AllowAnyMethod()
                                                                                 .WithOrigins("https://localhost:44338")));

            services.AddControllers()
                    .AddNewtonsoftJson()
                    .AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SSEA.Api", Version = "v1" });
                c.UseAllOfToExtendReferenceSchemas();
                c.EnableAnnotations();
            });

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LocalConnection")));

            services.AddIdentity<User, Role>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();

            var jwtSettings = Configuration.GetSection("JWTSettings");
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings["ValidIssuer"],
                    ValidAudience = jwtSettings["ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecurityKey"]))
                };
            });

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPerformanceLevelService, PerformanceLevelService>();
            services.AddScoped<ISafetyIntegrityLevelService, SafetyIntegrityLevelService>();

            services.AddScoped<CodeListRepository>();
            services.AddScoped<MachineRepository>();
            services.AddScoped<AccessPointRepository>();
            services.AddScoped<SafetyFunctionRepository>();
            services.AddScoped<SubsystemRepository>();
            services.AddScoped<UserRepository>();

            services.AddScoped<CodeListFacade>();
            services.AddScoped<MachineFacade>();
            services.AddScoped<AccessPointFacade>();
            services.AddScoped<SafetyFunctionFacade>();
            services.AddScoped<SubsystemFacade>();

            services.AddAutoMapper(typeof(ModelBase).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SSEA.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
