using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AdaTech.Api.Configuration
{
    public static class AuthenticationConfiguration
    {
        public static IServiceCollection AddCognitoAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var awsCognitoConfig = configuration.GetSection("AWS");
            var cognitoPoolId = awsCognitoConfig.GetValue<string>("UserPoolId");
            var cognitoRegion = awsCognitoConfig.GetValue<string>("Region");
            var cognitoAuthority = $"https://cognito-idp.{cognitoRegion}.amazonaws.com/{cognitoPoolId}";

            services.AddCognitoIdentity();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = cognitoAuthority;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = cognitoAuthority,
                    ValidateLifetime = true,
                    LifetimeValidator = (before, expires, token, param) => expires > DateTime.UtcNow,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                {
                    policy.RequireClaim("cognito:groups", "admin");
                });
            });

            return services;
        }
    }
}
