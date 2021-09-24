using Akeraiotitasoft.IOFacade.Mock;
using Akeraiotitasoft.IOFacade.SpecFlow.BDD.CUT;
//using Akeraiotitasoft.Samples.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Akeraiotitasoft.IOFacade.SpecFlow.BDD.Steps
{
    [Binding]
    public class TestIOSteps
    {
        private readonly MockStandardOutput _mockStandardOutput;
        private readonly MockStandardInput _mockStandardInput;
        private readonly MockStandardError _mockStandardError;
        private readonly ICalculator _calculator;

        private Task _task = null;
        

        public TestIOSteps(
            MockStandardOutput mockStandardOutput,
            MockStandardInput mockStandardInput,
            MockStandardError mockStandardError,
            ICalculator calculator)
        {
            _mockStandardOutput = mockStandardOutput;
            _mockStandardInput = mockStandardInput;
            _mockStandardError = mockStandardError;
            _calculator = calculator;
        }

        [When("I run the program")]
        public void RunProgram()
        {
            if (_task == null)
            {
                _task = Task.Run(() => _calculator.Execute());
            }
            else
            {
                throw new InvalidOperationException("The program is already running");
            }
        }

        [Then("the program terminates in less than (.*) seconds")]
        public void ProgramTerminates(int seconds)
        {
            if (_task == null)
            {
                throw new InvalidOperationException("The program is not running");
            }
            else
            {
                try
                {
                    bool result = _task.Wait(seconds * 1000);
                    if (result)
                    {
                        if (_task.Status != TaskStatus.RanToCompletion)
                        {
                            TaskStatus taskStatus = _task.Status;
                            throw new Exception($"Task status was {taskStatus}");
                        }
                    }
                    else
                    {
                        _task.Dispose();
                        throw new Exception($"Task was disposed because it did not complete in time.");
                    }
                }
                finally
                {
                    _task = null;
                }
            }
        }
    }
}
