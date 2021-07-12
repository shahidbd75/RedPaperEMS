using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedPaperEMS.Application.Contracts.Infrastructure;
using RedPaperEMS.Application.Models.Mail;
using RedPaperEMS.Infrastructure.Mail;

namespace RedPaperEMS.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailService, EmailService>();
            return services;
        }
    }
}
