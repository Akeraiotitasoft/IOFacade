using Akeraiotitasoft.DependencyInjection.Modules.Abstraction;
using Akeraiotitasoft.IOFacade.SpecFlow.BDD.CUT;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.IOFacade.SpecFlow.BDD.DependencyInjection
{
    public class CalculatorModule : IServiceCollectionModule
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ICalculator, Calculator>();
        }
    }
}
