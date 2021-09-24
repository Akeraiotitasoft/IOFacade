using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.IOFacade.Mock.Utilities
{
    internal static class StringUtilities
    {
        /// <summary>
        /// The various ways character sequences that terminate a line.
        /// </summary>
        private static string[] LINE_TERMINATORS => new[] { "\r\n", "\r", "\n" };

        public static string[] SplitOnLineTerminator(string input)
        {
            return input.Split(LINE_TERMINATORS, StringSplitOptions.None);
        }
    }
}
