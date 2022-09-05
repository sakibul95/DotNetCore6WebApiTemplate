using Microsoft.AspNetCore.HttpOverrides;
using System.Net;

namespace DotnetCore6WebApiTemplate.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
        }

        public static void ConfigureForwardHeader(this IServiceCollection services)
        {
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(IPAddress.Parse("10.0.0.100"));
            });
        }

        public static IServiceCollection ConfigureRepositoryInjections(this IServiceCollection services)
        {
            //services.AddTransient<IAccountRepository, AccountRepository>();
            //services.AddTransient<IQuizmasterRecurringPaymentRepository, QuizmasterRecurringPaymentRepository>();

            return services;
        }

        //public static void ConfigureJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        //    {
        //        options.RequireHttpsMetadata = false;
        //        options.SaveToken = true;
        //        options.TokenValidationParameters = new TokenValidationParameters()
        //        {
        //            ValidateIssuer = true,
        //            ValidateAudience = true,
        //            ValidAudience = configuration["JWT:ValidAudience"],
        //            ValidIssuer = configuration["JWT:ValidIssuer"],
        //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
        //        };
        //    });
        //}
    }
}
