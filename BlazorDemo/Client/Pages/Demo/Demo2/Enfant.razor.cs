using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Client.Pages.Demo.Demo2
{
    public partial class Enfant
    {
        [Parameter] 
        public string TextFromParent { get; set; }

        [Parameter]
        public EventCallback<string> MaReponse { get; set; }

        public void RepondAPapa(string reponse)
        {
            MaReponse.InvokeAsync(reponse);
        }
    }
}
