﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DeskUI.Shared.Window
{
    public partial class FloatingWindow : IDisposable
    {
        [Parameter] public string Title { get; set; } = "Window";
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public Guid Id { get; set; }
        [Parameter] public int ZIndex { get; set; }
        [Parameter] public int Top { get; set; }
        [Parameter] public int Left { get; set; }
        [Parameter] public int Width { get; set; }
        [Parameter] public EventCallback OnCloseRequested { get; set; }

        private string WindowId => $"window-{Id}";
        private string Style => $"position:fixed; top:{Top}px; left:{Left}px; width:{Width}px; z-index:{ZIndex};";

        protected override void OnInitialized()
        {
            WindowManager.OnThemeChanged += OnThemeChanged;
        }

        public void Dispose()
        {
            WindowManager.OnThemeChanged -= OnThemeChanged;
        }

        private void OnThemeChanged()
        {
            InvokeAsync(StateHasChanged);
        }

        private async Task OnMouseUp(MouseEventArgs _)
        {
            await WindowManager.StopDrag();
            await InvokeAsync(StateHasChanged);
        }

        private async Task BringToFront(MouseEventArgs _)
        {
            await WindowManager.BringToFront(Id);
            await InvokeAsync(StateHasChanged);
        }

        private void StartDrag(MouseEventArgs e)
        {
            WindowManager.StartDrag(Id, (int)e.ClientX, (int)e.ClientY);
        }

        private async Task Close()
        {
            await OnCloseRequested.InvokeAsync();
        }
    }
}
