using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace Akeraiotitasoft.IOFacade
{
    public class StandardInput : IStandardInput
    {
        public string? ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
