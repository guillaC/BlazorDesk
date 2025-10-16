using DeskUI.Shared.Components.Test;
using Radzen;
using System.Threading.Tasks;

namespace DeskUI.Pages
{
    public partial class Index
    {
        async Task OpenSecondComponent()
        {
            await WindowManager.Show("SecondComponent", builder =>
            {
                builder.OpenComponent<SecondComponent>(0);
                builder.CloseComponent();
            });
        }
        async Task OpenFirstComponent()
        {
           await WindowManager.Show("FirstComponent", builder =>
            {
                builder.OpenComponent<FirstComponent>(0);
                builder.CloseComponent();
            });
        }
    }
}
