using System;

namespace ova.Common.Logging.Shared
{
    public abstract partial class LoggerProvider : IDisposable 
    {
        protected IDisposable SettingsChangeToken;
        void IDisposable.Dispose()
        {
            if (!this.IsDisposed)
            {
                try { Dispose(true); }
                catch { }
                this.IsDisposed = true;
                GC.SuppressFinalize(this);  // instructs GC not bother to call the destructor   
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (SettingsChangeToken != null)
            {
                SettingsChangeToken.Dispose();
                SettingsChangeToken = null;
            }
        }
        ~LoggerProvider() { if (!this.IsDisposed) { Dispose(false); } }
        public bool IsDisposed { get; protected set; }
    }
}