using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace DeskUI.Shared.Window
{
    public partial class WindowHost
    {
        private DotNetObjectReference<WindowHost>? _dotNetRef;

        protected override void OnInitialized()
        {
            WindowManager.OnChange += async () => await InvokeAsync(StateHasChanged);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _dotNetRef = DotNetObjectReference.Create(this);
                await JSRuntime.InvokeVoidAsync("trackMouseMove", _dotNetRef);
            }
        }

        [JSInvokable]
        public Task HandleMouseMove(int x, int y)
        {
            if (!WindowManager.IsDragging) return Task.CompletedTask;
            return WindowManager.HandleMouseMove(x, y);
        }

        private async Task OnMouseUp(MouseEventArgs e)
        {
            await WindowManager.StopDrag();
        }
    }
}
