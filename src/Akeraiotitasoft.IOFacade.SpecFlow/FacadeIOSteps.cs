using Akeraiotitasoft.IOFacade.Mock;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Akeraiotitasoft.IOFacade.SpecFlow
{
    [Binding]
    public sealed class FacadeIOSteps
    {
        private readonly MockStandardOutput _mockStandardOutput;
        private readonly MockStandardInput _mockStandardInput;
        private readonly MockStandardError _mockStandardError;

        public FacadeIOSteps(
            MockStandardOutput mockStandardOutput,
            MockStandardInput mockStandardInput,
            MockStandardError mockStandardError)
        {
            _mockStandardOutput = mockStandardOutput;
            _mockStandardInput = mockStandardInput;
            _mockStandardError = mockStandardError;
        }

        [Given(@"the user types ""(.*)"" followed by enter")]
        public void GivenTheUserTypes(string input)
        {
            _mockStandardInput.Enqueue(input);
        }

        [Then(@"the standard input is blocked on wait in less than (.*) seconds")]
        public void GivenTheUserTypes(int seconds)
        {
            DateTime begin = DateTime.UtcNow;
            bool waitingForInput;
            while (!(waitingForInput = _mockStandardInput.WaitingForInput) && (DateTime.UtcNow - begin).TotalSeconds < seconds)
            {
                Thread.Sleep(100);
            }
            if (!waitingForInput)
            {
                throw new InvalidOperationException("Did not block on input in time");
            }
        }

        [Then(@"the number of output lines is (.*)")]
        public void TheNumberOfOutputLinesIs(int count)
        {
            _mockStandardOutput.GetOutputBuffer().Count().Should().Be(count, "we are checking the number of lines against an expected number of lines");
        }

        [Then(@"the value of output line (.*) is ""(.*)""")]
        public void TheValueOfOutputLineIs(int line, string input)
        {
            string value = _mockStandardOutput.GetOutputBuffer().ElementAt(line);
            value.Should().Be(input);
        }

        [Then(@"the value of output line (.*) is equivalent to ""(.*)""")]
        public void TheValueOfOutputLineIsEquivalentTo(int line, string input)
        {
            string value = _mockStandardOutput.GetOutputBuffer().ElementAt(line);
            value.Should().BeEquivalentTo(input);
        }

        [Then(@"the substring value of output line (.*) is ""(.*)"" from (.*) for (.*) characters")]
        public void TheSubstringValueOfOutputLineIs(int line, string input, int fromCharacterIndex, int forCharacterCount)
        {
            string value = _mockStandardOutput.GetOutputBuffer().ElementAt(line);
            value.Substring(fromCharacterIndex, forCharacterCount).Should().Be(input);
        }

        [Then(@"the substring value of output line (.*) is equivalent to ""(.*)"" from (.*) for (.*) characters")]
        public void TheSubstringValueOfOutputLineIsEquivalentTo(int line, string input, int fromCharacterIndex, int forCharacterCount)
        {
            string value = _mockStandardOutput.GetOutputBuffer().ElementAt(line);
            value.Substring(fromCharacterIndex, forCharacterCount).Should().BeEquivalentTo(input);
        }

        [Given("the standard output is cleared")]
        public void TheStandardOutputIsCleared()
        {
            _mockStandardOutput.Clear();
        }

        [Then(@"the number of error lines is (.*)")]
        public void TheNumberOfErrorLinesIs(int count)
        {
            _mockStandardError.GetOutputBuffer().Count().Should().Be(count, "we are checking the number of lines against an expected number of lines");
        }

        [Then(@"the value of error line (.*) is ""(.*)""")]
        public void TheValueOfErrorLineIs(int line, string input)
        {
            string value = _mockStandardError.GetOutputBuffer().ElementAt(line);
            value.Should().Be(input);
        }

        [Then(@"the value of error line (.*) is equivalent to ""(.*)""")]
        public void TheValueOfErrorLineIsEquivalentTo(int line, string input)
        {
            string value = _mockStandardError.GetOutputBuffer().ElementAt(line);
            value.Should().BeEquivalentTo(input);
        }

        [Then(@"the substring value of error line (.*) is ""(.*)"" from (.*) for (.*) characters")]
        public void TheSubstringValueOfErrorLineIs(int line, string input, int fromCharacterIndex, int forCharacterCount)
        {
            string value = _mockStandardError.GetOutputBuffer().ElementAt(line);
            value.Substring(fromCharacterIndex, forCharacterCount).Should().Be(input);
        }

        [Then(@"the substring value of error line (.*) is  equivalent to ""(.*)"" from (.*) for (.*) characters")]
        public void TheSubstringValueOfErrorLineIsEquivalentTo(int line, string input, int fromCharacterIndex, int forCharacterCount)
        {
            string value = _mockStandardError.GetOutputBuffer().ElementAt(line);
            value.Substring(fromCharacterIndex, forCharacterCount).Should().BeEquivalentTo(input);
        }

        [Given("the standard error is cleared")]
        public void TheStandardErrorIsCleared()
        {
            _mockStandardError.Clear();
        }
    }
}
