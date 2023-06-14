using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Client.Pages.Exercices.Exo2
{
    public class GameForm
    {
        [Required(ErrorMessage = "Le titre est requis")]
        public string Titre { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public int DateDeSortie { get; set; }
        [Range(0, 5, ErrorMessage = "La note est comprise entre 0 et 5")]
        public int Note { get; set; }
    }
}
