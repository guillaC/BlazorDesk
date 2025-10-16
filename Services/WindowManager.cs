using Microsoft.AspNetCore.Components;

namespace DeskUI.Services
{
    public class WindowManager
    {
        public event Func<Task>? OnChange;
        private int _zCounter = 1000;

        public List<WindowInstance> Windows { get; } = new();

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

        public WindowInstance? GetWindow(Guid id)
            => Windows.FirstOrDefault(w => w.Id == id);

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

        public async Task UpdatePosition(Guid id, int top, int left, int width)
        {
            var win = GetWindow(id);
            if (win != null)
            {
                win.Top = top;
                win.Left = left;
                win.Width = width;
                if (OnChange != null) await OnChange.Invoke();
            }
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
