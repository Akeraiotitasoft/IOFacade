using System;

#nullable enable

namespace Akeraiotitasoft.IOFacade
{
    public class StandardOutput : IStandardOutput
    {
        public void Write(string? text)
        {
            Console.Write(text);
        }

        public void WriteLine(string? text)
        {
            Console.WriteLine(text);
        }
    }
}
