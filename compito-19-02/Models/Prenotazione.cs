namespace compito_19_02.Models
{
    public class Prenotazione
    {
        public Guid Id = Guid.NewGuid();
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public Sale Sala { get; set; }
        public Biglietto TipoBiglietto { get; set; }

    }
}
