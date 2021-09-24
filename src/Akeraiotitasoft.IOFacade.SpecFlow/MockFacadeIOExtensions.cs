using Akeraiotitasoft.IOFacade;
using Akeraiotitasoft.IOFacade.Mock;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Akeraiotitasoft.IOFacade.SpecFlow
{
    public static class MockFacadeIOExtensions
    {
        public static IServiceCollection AddMockFacadeIO(this IServiceCollection services)
        {
            services.AddSingleton<MockStandardInput>();
            services.AddSingleton<IStandardInput>(x => x.GetRequiredService<MockStandardInput>());

            services.AddSingleton<MockStandardOutput>();
            services.AddSingleton<IStandardOutput>(x => x.GetRequiredService<MockStandardOutput>());

            services.AddSingleton<MockStandardError>();
            services.AddSingleton<IStandardError>(x => x.GetRequiredService<MockStandardError>());

            return services;
        }
    }
}
