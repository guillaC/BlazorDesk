using DeskUI.Shared.Components.Test;

namespace DeskUI.Pages
{
    public partial class Index
    {
        async Task OpenFirstComponent()
        {
           await WindowManager.Show("FirstComponent", builder =>
            {
                builder.OpenComponent<FirstComponent>(0);
                builder.CloseComponent();
            }, width: 300);
        }

        async Task OpenSecondComponent()
        {
            await WindowManager.Show("SecondComponent", builder =>
            {
                builder.OpenComponent<SecondComponent>(0);
                builder.CloseComponent();
            }, width: 900);
        }
    }
}
