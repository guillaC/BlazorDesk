using DeskUI.Shared.Components.Forms;

namespace DeskUI.Pages
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
             }, width: 300);
        }

        async Task OpenSecondWindow()
        {
            await WindowManager.Show("SecondComponent", builder =>
            {
                builder.OpenComponent<SecondForm>(0);
                builder.CloseComponent();
            }, width: 600);
        }
    }
}
