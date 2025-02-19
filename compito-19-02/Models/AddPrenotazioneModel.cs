using System.ComponentModel.DataAnnotations;

namespace compito_19_02.Models
{
    public class AddPrenotazioneModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Il nome è obbligatorio!")]
        [StringLength(20, ErrorMessage = "Il nome deve essere compreso tra 2 e 20 caratteri", MinimumLength = 2)]
        public string Nome { get; set; }

        [Display(Name = "Cognome")]
        [Required(ErrorMessage = "Il cognome è obbligatorio!")]
        [StringLength(20, ErrorMessage = "La descrizione deve essere compresa tra 2 e 20 caratteri", MinimumLength = 2)]
        public string Cognome { get; set; }

        [Display(Name = "Sala")]
        [Required(ErrorMessage = "La scelta della sala è obbligatoria!")]
        public Sale Sala { get; set; }

        [Display(Name = "Biglietto")]
        [Required(ErrorMessage = "La scelta del tipo di biglietto è obbligatoria!")]
        public Biglietto TipoBiglietto { get; set; }
    }
}
