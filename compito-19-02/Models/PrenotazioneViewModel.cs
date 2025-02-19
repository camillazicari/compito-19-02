namespace compito_19_02.Models
{
    public class PrenotazioneViewModel
    {
        public int TotaleNord { get; set; } = 0;
        public int RidottiNord { get; set; } = 0;
        public int TotaleEst { get; set; } = 0;
        public int RidottiEst { get; set; } = 0;
        public int TotaleSud { get; set; } = 0;
        public int RidottiSud { get; set; } = 0;
        public List<Prenotazione> Prenotazione { get; set; } = new List<Prenotazione>();

    }
}
