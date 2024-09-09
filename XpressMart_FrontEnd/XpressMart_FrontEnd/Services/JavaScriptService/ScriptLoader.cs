using Microsoft.JSInterop;

namespace XpressMart_FrontEnd.Services.JavaScriptService
{
    public abstract class ScriptLoader
    {
        protected readonly IJSRuntime JSRuntime;
        protected readonly string ScriptPath;

        protected ScriptLoader(IJSRuntime jsRuntime, string scriptPath)
        {
            JSRuntime = jsRuntime;
            ScriptPath = scriptPath;
        }

        public async ValueTask EnsureLoadedAsync()
        {
            await JSRuntime.InvokeVoidAsync("loadScript", ScriptPath);
        }
    }
}
