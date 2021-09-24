using Akeraiotitasoft.IOFacade.Mock.Utilities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Akeraiotitasoft.IOFacade.Mock
{
    public class MockStandardOutput : IStandardOutput
    {
        private ReaderWriterLockSlim _readerWriterLockSlim = new ReaderWriterLockSlim();
        private List<string> _outputBuffer = new List<string>();
        private StringBuilder _currentLine = new StringBuilder();

        public IEnumerable<string> GetOutputBuffer()
        {
            _readerWriterLockSlim.EnterReadLock();
            try
            {
                return _outputBuffer.ToArray();
            }
            finally
            {
                _readerWriterLockSlim.ExitReadLock();
            }
        }

        public string GetCurrentLine()
        {
            _readerWriterLockSlim.EnterReadLock();
            try
            {
                return _currentLine.ToString();
            }
            finally
            {
                _readerWriterLockSlim.ExitReadLock();
            }
        }

        public void Clear()
        {
            _readerWriterLockSlim.EnterWriteLock();
            try
            {
                _outputBuffer.Clear();
                _currentLine.Clear();
            }
            finally
            {
                _readerWriterLockSlim.ExitWriteLock();
            }
        }

        public void Write(string text)
        {
            _readerWriterLockSlim.EnterWriteLock();
            try
            {
                string[] lines = StringUtilities.SplitOnLineTerminator(text);
                if (lines.Length == 1)
                {
                    _currentLine.Append(lines[0]);
                }
                else
                {
                    _outputBuffer.Add(_currentLine.ToString() + lines[0]);
                    _currentLine.Clear();
                    for (int i = 1; i < (lines.Length - 1); i++)
                    {
                        _outputBuffer.Add(lines[i]);
                    }
                    _currentLine.Append(lines[lines.Length - 1]);
                }
            }
            finally
            {
                _readerWriterLockSlim.ExitWriteLock();
            }
        }

        public void WriteLine(string text)
        {
            _readerWriterLockSlim.EnterWriteLock();
            try
            {
                string[] lines = StringUtilities.SplitOnLineTerminator(text);
                if (lines.Length == 1)
                {
                    _outputBuffer.Add(_currentLine.ToString() + lines[0]);
                    _currentLine.Clear();
                }
                else
                {
                    _outputBuffer.Add(_currentLine.ToString() + lines[0]);
                    _currentLine.Clear();
                    for (int i = 1; i < lines.Length; i++)
                    {
                        _outputBuffer.Add(lines[i]);
                    }
                }
            }
            finally
            {
                _readerWriterLockSlim.ExitWriteLock();
            }
        }
    }
}
