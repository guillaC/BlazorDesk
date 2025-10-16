using Microsoft.AspNetCore.Components;

namespace DeskUI.Services
{
    public class WindowManager
    {
        public event Func<Task>? OnChange;
        private int _zCounter = 1000;
        public List<WindowInstance> Windows { get; } = new();

        public async Task Show(string title, RenderFragment content)
        {
            var id = Guid.NewGuid();
            Windows.Add(new WindowInstance
            {
                Id = id,
                Title = title,
                Content = content,
                ZIndex = ++_zCounter
            });

            if (OnChange != null) await OnChange.Invoke();
        }

        public int GetZIndex(Guid id)
        {
            var win = Windows.FirstOrDefault(w => w.Id == id);
            return win?.ZIndex ?? 0;
        }

        public async Task BringToFront(Guid id)
        {
            var win = Windows.FirstOrDefault(w => w.Id == id);
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

        public async Task UpdatePosition(Guid id, int top, int left)
        {
            var win = Windows.FirstOrDefault(w => w.Id == id);
            if (win != null)
            {
                win.Top = top;
                win.Left = left;

                Console.WriteLine($"UpdatePosition: {top}, {left}");

                if (OnChange != null) await OnChange.Invoke();
            }
        }
    }

    public class WindowInstance
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = "";
        public RenderFragment? Content { get; set; }
        public int ZIndex { get; set; } = 1000;
        public int Top { get; set; } = 100;
        public int Left { get; set; } = 100;
    }
}
