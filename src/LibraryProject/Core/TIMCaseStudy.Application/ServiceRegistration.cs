using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TIMCaseStudy.Application
{
    public static class ServiceRegistrationü
    {
        public static IServiceCollection AddApplicationServicesRegistration(this IServiceCollection services)
        {
            var assmbly = Assembly.GetExecutingAssembly();
            services.AddMediatR(assmbly);
            services.AddAutoMapper(assmbly);
            services.AddValidatorsFromAssembly(assmbly);
            return services;
        }
    }
}
