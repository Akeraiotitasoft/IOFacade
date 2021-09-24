using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace Akeraiotitasoft.IOFacade
{
    /// <summary>
    /// The standard error abstraction interface
    /// </summary>
    public interface IStandardError
    {
        /// <summary>
        /// Write a line of text to the standard error
        /// </summary>
        /// <param name="text">The text to write</param>
        void WriteLine(string? text);

        /// <summary>
        /// Write text to the standard error without going to the next line
        /// </summary>
        /// <param name="text">The text to write</param>
        void Write(string? text);
    }
}
