using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Mailing.Mailkit;

namespace Core.Mailing;

public static class MailingServiceRegistration
{
    public static IServiceCollection AddMailingServices(this IServiceCollection services,IConfiguration configuration)
    {

        services.Configure<MailSettings>(options=>
            configuration.GetSection("MailSettings").Bind(options)
        );
        services.AddScoped<IMailService,MailKitMailService>();

        return services;
    }

}
