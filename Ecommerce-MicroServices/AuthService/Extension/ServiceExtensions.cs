using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AuthService.Extension
{
    public static class ServiceExtensions
    {
        public static void AddJwt(this IServiceCollection services, ConfigurationManager configuration, IWebHostEnvironment hostEnvironment)
        {
           // var parent = System.IO.Directory.GetParent (hostEnvironment.ContentRootPath);
            var sharedFolder = Path.Combine(hostEnvironment.ContentRootPath, @"..\");

            configuration.AddJsonFile(Path.Combine(sharedFolder, "SharedSettings.json"), optional: true) // When running using dotnet run
                    .AddJsonFile("SharedSettings.json", optional: true) // When app is published
                    .AddJsonFile("appsettings.json", optional: true);
            configuration.AddEnvironmentVariables();
            var secretKey = configuration.GetValue<string>("SecreteKey");
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "https://localhost:44391",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            }
          );
        }
    }
}
