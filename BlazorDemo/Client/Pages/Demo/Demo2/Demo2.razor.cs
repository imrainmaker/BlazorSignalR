namespace BlazorDemo.Client.Pages.Demo.Demo2
{
    public partial class Demo2
    {
        public string MyText { get; set; } = "Salut gamin comment ça va ?";

        public string ReponseDeEnfant { get; set; }

        public void RecevoirReponse(string reponse)
        {
            ReponseDeEnfant = reponse;
        }
    }
}
