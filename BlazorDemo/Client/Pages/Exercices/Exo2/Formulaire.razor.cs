using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Client.Pages.Exercices.Exo2
{
    public partial class Formulaire
    {
        public GameForm MyForm { get; set; }

        [Parameter]
        public EventCallback<GameForm> NotifyNewGame { get; set; }

        public Formulaire()
        {
            MyForm = new GameForm();
        }

        private void Submit()
        {
            NotifyNewGame.InvokeAsync(MyForm);
            MyForm = new GameForm();
        }
    }
}
