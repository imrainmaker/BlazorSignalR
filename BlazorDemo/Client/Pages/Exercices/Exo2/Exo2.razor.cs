using BlazorDemo.Client.Pages.Demo.Demo7;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System.Net.Http.Json;

namespace BlazorDemo.Client.Pages.Exercices.Exo2
{
    public partial class Exo2
    {
        public List<Game> Games { get; set; } = new List<Game>();
        public int SelectedGame { get; set; }

        [Inject]
        public HttpClient client { get; set; }

        public HubConnection MyHub { get; set; }

        protected override async Task OnInitializedAsync()
        {

            Games = await client.GetFromJsonAsync<List<Game>>("game");
            MyHub = new HubConnectionBuilder()
                .WithUrl(new Uri("https://localhost:7275/chathub")).Build();

            MyHub.On("newGameList", async () =>
            {
                await RefreshList();
                StateHasChanged();
            });

            await MyHub.StartAsync();
            await RefreshList();
        }

        private async Task RefreshList()
        {
            Games = await client.GetFromJsonAsync<List<Game>>("game");
        }

        public async Task AddGame(GameForm form)
        {
            Game myGame = new Game
            {

                Titre = form.Titre,
                Genre = form.Genre,
                DateDeSortie = form.DateDeSortie,
                Note = form.Note
            };


            await client.PostAsJsonAsync<Game>("game", myGame);

            await RefreshList();

        }

        public void SelectGame(int id)
        {
            SelectedGame = id;
        }
    }
}
