using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorDemo.Client.Pages.Demo.Demo4
{
    public partial class Demo4
    {
        [Inject]
        public IJSRuntime js { get; set; }
        public async Task Stock()
        {
            await js.InvokeVoidAsync("localStorage.setItem", "info", "Salut les gars !");
            //await js.InvokeVoidAsync("alert", "Tu fais chier le prof !");
            //await js.InvokeAsync<object>("maFonction");
        }
    }
}
