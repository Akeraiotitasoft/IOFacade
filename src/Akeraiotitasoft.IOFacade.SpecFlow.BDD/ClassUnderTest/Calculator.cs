using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.IOFacade.SpecFlow.BDD.CUT
{
    /// <summary>
    /// Class Under Test
    /// </summary>
    public class Calculator : ICalculator
    {
        private readonly IStandardInput _standardInput;
        private readonly IStandardOutput _standardOutput;
        private readonly IStandardError _standardError;

        public Calculator(IStandardInput standardInput, IStandardOutput standardOutput, IStandardError standardError)
        {
            if (standardInput is null)
            {
                throw new ArgumentNullException(nameof(standardInput));
            }

            if (standardOutput is null)
            {
                throw new ArgumentNullException(nameof(standardOutput));
            }

            if (standardError is null)
            {
                throw new ArgumentNullException(nameof(standardError));
            }

            _standardInput = standardInput;
            _standardOutput = standardOutput;
            _standardError = standardError;
        }

        public void Execute()
        {
            int? first = null;
            int? second = null;
            string operation = null;

            bool quit = false;
            while (!quit)
            {
                _standardOutput.WriteLine("-- MENU --");
                _standardOutput.WriteLine("input) input a number");
                _standardOutput.WriteLine("add) add command");
                _standardOutput.WriteLine("subtract) subtract command");
                _standardOutput.WriteLine("multiply) multiply command");
                _standardOutput.WriteLine("divide) divide command");
                _standardOutput.WriteLine("equals) equals command");
                _standardOutput.WriteLine("quit) quit program");

                string input = _standardInput.ReadLine();
                switch (input)
                {
                    case "input":
                        {
                            if (first == null && operation == null)
                            {
                                first = int.Parse(_standardInput.ReadLine());
                            }
                            else if (operation != null && second == null)
                            {
                                second = int.Parse(_standardInput.ReadLine());
                            }
                            else
                            {
                                throw new FluentAssertions.Execution.AssertionFailedException("The input buffer is already full or there is no operation");
                            }
                        }
                        break;
                    case "add":
                    case "subtract":
                    case "multiply":
                    case "divide":
                        {
                            if (first != null && operation == null)
                            {
                                operation = input;
                            }
                            else
                            {
                                throw new FluentAssertions.Execution.AssertionFailedException("The input buffer is already full");
                            }
                        }
                        break;
                    case "equals":
                        {
                            if (first != null && operation != null && second != null)
                            {
                                switch (operation)
                                {
                                    case "add":
                                        first = first + second;
                                        break;
                                    case "subtract":
                                        first = first - second;
                                        break;
                                    case "multiply":
                                        first = first * second;
                                        break;
                                    case "divide":
                                        first = first / second;
                                        break;
                                }
                                operation = null;
                                second = null;
                                _standardOutput.WriteLine("result = " + first);
                            }
                        }
                        break;
                    case "quit":
                        quit = true;
                        break;
                }
            }
        }
    }
}
