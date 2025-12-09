using DeskUI.Services;
using DeskUI.Demo.Shared.Components.Forms;

namespace DeskUI.Demo.Pages
{
    public partial class Index
    {
        private void ToggleTheme()
        {
            WindowManager.SetDarkMode(!WindowManager.DarkModeColours);
        }

        async Task OpenFirstWindow()
        {
            await WindowManager.Show("FirstComponent", builder =>
             {
                 builder.OpenComponent<FirstForm>(0);
                 builder.CloseComponent();
             }, width: 240, height: 320);
        }

        async Task OpenSecondWindow()
        {
            await WindowManager.Show("SecondComponent (AllowClose = false)", builder =>
            {
                builder.OpenComponent<SecondForm>(0);
                builder.CloseComponent();
            }, width: 550, height: 250, allowClose: false);
        }

        async Task OpenUIManagerWindow()
        {
            await WindowManager.Show("UIManager", builder =>
            {
                builder.OpenComponent<UIManagerForm>(0);
                builder.CloseComponent();
            }, width: 800, height: 400);
        }
    }
}
