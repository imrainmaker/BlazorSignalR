using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Client.Pages.Exercices.Exo1
{
    public partial class Questions
    {
        [Parameter]
        public string Username { get; set; }

        [Parameter]
        public EventCallback<string> NotifyResponse { get; set; }

        [Parameter]
        public EventCallback NotifyEndGame { get; set; }

        public List<string> QuestionList { get; set; }
        public int Counter { get; set; }

        public string CurrentQuestion { get; set; }

        public Questions()
        {
            QuestionList = new List<string>();
            QuestionList.Add("Avez vous bien mangé à midi ?");
            QuestionList.Add("Vous pouvez me faire griller un porcelet ?");
            QuestionList.Add("Ca va ? pas trop dur Blazor ?");

            Counter = 0;
            CurrentQuestion = QuestionList[Counter];
            Counter++;
        }

        public void DonnerReponse(string rep)
        {
            NotifyResponse.InvokeAsync(rep);

            if(Counter < QuestionList.Count)
            {
                CurrentQuestion = QuestionList[Counter];
            }
            else
            {
                NotifyEndGame.InvokeAsync();
            }
            Counter++;
        }
    }
}
