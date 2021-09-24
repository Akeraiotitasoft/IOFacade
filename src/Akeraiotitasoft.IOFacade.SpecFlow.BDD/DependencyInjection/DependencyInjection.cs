using Microsoft.Extensions.DependencyInjection;
using Akeraiotitasoft.IOFacade.SpecFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akeraiotitasoft.SpecFlow.DependencyInjection.SpecFlowPlugin;
using Akeraiotitasoft.IOFacade.SpecFlow.BDD.CUT;
//using Akeraiotitasoft.DependencyInjection.Modules;

namespace Akeraiotitasoft.IOFacade.SpecFlow.BDD.DependencyInjection
{
    public static class DependencyInjection
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServiceCollection()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddMockFacadeIO();
            services.AddSingleton<ICalculator, Calculator>();
            services.AddLogging();
            //services.LoadModule<ServiceCollectionRegistration>();
            return services;
        }
    }

    //public class CalculatorModule : IServiceCollectionModule
    //{

    //}
}
