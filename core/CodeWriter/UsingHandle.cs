using System;

namespace CodeWriter
{
    public class UsingHandle : IDisposable
    {
        private Action _disposed;

        public UsingHandle(Action disposed)
        {
            _disposed = disposed;
        }

        public void Dispose()
        {
            if (_disposed != null)
            {
                _disposed();
                _disposed = null;
            }
        }
    }
}
