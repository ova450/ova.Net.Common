using Microsoft.Extensions.Logging;

namespace ova.Common.Logging.Shared
{
    public abstract partial class LoggerProvider :   ISupportExternalScope
    {
        IExternalScopeProvider fScopeProvider;
        void ISupportExternalScope.SetScopeProvider(IExternalScopeProvider scopeProvider)
        { fScopeProvider = scopeProvider; }

        internal IExternalScopeProvider ScopeProvider
        {
            get
            {
                if (fScopeProvider == null) fScopeProvider = new LoggerExternalScopeProvider();
                return fScopeProvider;
            }
        }
    }
}