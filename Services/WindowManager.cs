using Microsoft.AspNetCore.Components;

namespace DeskUI.Services
{
    public class WindowManager
    {
        public event Func<Task>? OnChange;
        public event Action? OnThemeChanged;

        private int _zCounter = 1000;
        public List<WindowInstance> Windows { get; } = new();
        public bool DarkModeColours { get; private set; } = false;
        public DragContext? Dragged { get; private set; }
        public bool IsDragging => Dragged is not null;
        public record DragContext(WindowInstance Window, int StartX, int StartY, int InitialLeft, int InitialTop);

        public async Task Show(string title, RenderFragment content, int width = 600, int top = 100, int left = 100)
        {
            var id = Guid.NewGuid();
            Windows.Add(new WindowInstance
            {
                Id = id,
                Title = title,
                Content = content,
                Width = width,
                Top = top,
                Left = left,
                ZIndex = ++_zCounter
            });

            if (OnChange != null) await OnChange.Invoke();
        }

        public WindowInstance? GetWindow(Guid id) => Windows.FirstOrDefault(w => w.Id == id);

        public void StartDrag(Guid id, int startX, int startY)
        {
            var win = GetWindow(id);
            if (win is null) return;

            Dragged = new DragContext(win, startX, startY, win.Left, win.Top);
        }

        public Task StopDrag()
        {
            Dragged = null;
            return Task.CompletedTask;
        }

        public async Task HandleMouseMove(int clientX, int clientY)
        {
            if (Dragged is null) return;

            var dx = clientX - Dragged.StartX;
            var dy = clientY - Dragged.StartY;

            Dragged.Window.Left = Dragged.InitialLeft + dx;
            Dragged.Window.Top = Dragged.InitialTop + dy;

            if (OnChange != null)
                await OnChange.Invoke();
        }

        public async Task BringToFront(Guid id)
        {
            var win = GetWindow(id);
            if (win != null)
            {
                win.ZIndex = ++_zCounter;
                if (OnChange != null) await OnChange.Invoke();
            }
        }

        public void Close(Guid id)
        {
            Windows.RemoveAll(w => w.Id == id);
            OnChange?.Invoke();
        }

        public async Task UpdatePosition(Guid id, int top, int left, int? width = null)
        {
            var win = GetWindow(id);
            if (win != null)
            {
                win.Top = top;
                win.Left = left;
                if (width is not null) win.Width = width.Value;
                if (OnChange != null) await OnChange.Invoke();
            }
        }

        public void SetDarkMode(bool state)
        {
            DarkModeColours = state;
            OnThemeChanged?.Invoke();
        }
    }

    public class WindowInstance
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = "";
        public RenderFragment? Content { get; set; }
        public int ZIndex { get; set; }
        public int Width { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }
    }
}
