namespace BlazorDemo.Client.Pages.Exercices.Exo1
{
    public partial class Quizz
    {
        public string Username { get; set; }

        public List<string> Reponses { get; set; }

        public bool IsQuizzFinished { get; set; }

        public Quizz()
        {
            Reponses = new List<string>();
        }

        public void AjoutReponse(string rep)
        {
            Reponses.Add(rep);
        }

        public void FinishQuizz()
        {
            IsQuizzFinished = true;
        }
    }
}
