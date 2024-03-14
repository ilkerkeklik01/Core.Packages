using Core.Security.Authenticator.EmailAuthenticator;
using Core.Security.Authenticator.OtpAuthenticator;
using Core.Security.Authenticator.OtpAuthenticator.OtpNet;
using Core.Security.JWT;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security;

public static class SecurityServiceRegistration
{
    public static IServiceCollection AddSecurityServices(this IServiceCollection services,IConfiguration configuration)
    {

        services.AddScoped<ITokenHelper, JwtHelper>();
        services.AddScoped<IEmailAuthenticatorHelper, EmailAuthenticatorHelper>();
        services.AddScoped<IOtpAuthenticatorHelper, OtpNetOtpAuthenticatorHelper>();

        const string configurationSection = "TokenOptions";
        var tokenOptionsSection = configuration.GetSection(configurationSection);

        if (!tokenOptionsSection.Exists())
        {
            throw new NullReferenceException($"\"{configurationSection}\" section cannot be found in configuration.");
        }

        services.Configure<TokenOptions>(options => tokenOptionsSection.Bind(options));
        

        return services;
    }


}
