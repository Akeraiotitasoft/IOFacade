using System;

#nullable enable

namespace Akeraiotitasoft.IOFacade
{
    /// <summary>
    /// The standard output abstraction interface
    /// </summary>
    public interface IStandardOutput
    {
        /// <summary>
        /// Write a line of text to the standard output
        /// </summary>
        /// <param name="text">The text to write</param>
        void WriteLine(string? text);

        /// <summary>
        /// Write text to the standard output without going to the next line
        /// </summary>
        /// <param name="text">The text to write</param>
        void Write(string? text);
    }
}
