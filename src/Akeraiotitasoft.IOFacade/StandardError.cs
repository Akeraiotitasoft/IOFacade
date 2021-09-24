using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace Akeraiotitasoft.IOFacade
{
    public class StandardError : IStandardError
    {
        public void Write(string? text)
        {
            Console.Error.Write(text);
        }

        public void WriteLine(string? text)
        {
            Console.Error.WriteLine(text);
        }
    }
}
