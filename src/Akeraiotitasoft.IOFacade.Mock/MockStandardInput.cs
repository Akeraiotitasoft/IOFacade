using Akeraiotitasoft.IOFacade.Mock.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace Akeraiotitasoft.IOFacade.Mock
{
    public class MockStandardInput : IStandardInput
    {
        private ConcurrentQueue<string> _inputQueue = new ConcurrentQueue<string>();
        private EventWaitHandle _eventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);

        private object _lock = new object();
        private bool _waitingForInput = false;

        public bool WaitingForInput
        {
            get
            {
                lock (_lock)
                {
                    return _waitingForInput;
                }
            }
        }

        public void Enqueue(string input)
        {
            _inputQueue.Enqueue(input);
            _eventWaitHandle.Set();
        }

        public void Enqueue(IEnumerable<string> input)
        {
            input.ForEach(_inputQueue.Enqueue);
            _eventWaitHandle.Set();
        }

        public string? ReadLine()
        {
            while (true)
            {
                string? result;
                if (_inputQueue.TryDequeue(out result))
                {
                    return result;
                }
                if (_inputQueue.Count > 0)
                {
                    continue;
                }
                lock (_lock)
                {
                    _waitingForInput = true;
                }
                try
                {
                    _eventWaitHandle.WaitOne();
                }
                finally
                {
                    lock (_lock)
                    {
                        _waitingForInput = false;
                    }
                }
            }
        }
    }
}
