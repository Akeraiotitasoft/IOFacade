using Akeraiotitasoft.IOFacade;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Akeraiotitasoft.IOFacade.DependencyInjection
{
    public static class FacadeIOExtensions
    {
        public static IServiceCollection AddFacadeIO(this IServiceCollection services)
        {
            services.AddSingleton<IStandardInput, StandardInput>();
            services.AddSingleton<IStandardOutput, StandardOutput>();
            services.AddSingleton<IStandardError, StandardError>();
            return services;
        }
    }
}
