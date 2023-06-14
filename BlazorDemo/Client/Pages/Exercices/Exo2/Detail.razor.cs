using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorDemo.Client.Pages.Exercices.Exo2
{
    public partial class Detail
    {
        [Inject]
        public HttpClient client { get; set; }

        [Parameter]
        public int CurrentId { get; set; }

        public Game CurrentGame { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            CurrentGame = await client.GetFromJsonAsync<Game>("game/" + CurrentId);
        }
    }
}
