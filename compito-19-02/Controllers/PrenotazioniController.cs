using System.Reflection;
using compito_19_02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace compito_19_02.Controllers
{
    public class PrenotazioniController : Controller
    {
        new static List<Prenotazione> prenotazione = new List<Prenotazione>
        {
           new Prenotazione()
           {
               Id = Guid.NewGuid(),
               Nome = "Camilla",
               Cognome = "Zicari",
               Sala = Sale.SalaNord,
               TipoBiglietto = Biglietto.Intero
           },

           new Prenotazione()
           {
               Id = Guid.NewGuid(),
               Nome = "Beatrice",
               Cognome = "Zorzi",
               Sala = Sale.SalaSud,
               TipoBiglietto = Biglietto.Ridotto
           },

           new Prenotazione()
           {
               Id = Guid.NewGuid(),
               Nome = "Antonio",
               Cognome = "Rossi",
               Sala = Sale.SalaEst,
               TipoBiglietto = Biglietto.Intero
           }
        };

        public IActionResult Index()
        {
            var prenot = new PrenotazioneViewModel()
            {
                Prenotazione = prenotazione
            };

            return View(prenot);
        }

        public IActionResult Add()
        {
            ViewBag.SaleDisponibili = Enum.GetValues(typeof(Sale))
                                  .Cast<Sale>()
                                  .Select(s => new SelectListItem { Value = s.ToString(), Text = s.ToString() })
                                  .ToList();

            ViewBag.BigliettiDisponibili = Enum.GetValues(typeof(Biglietto))
                                  .Cast<Biglietto>()
                                  .Select(b => new SelectListItem { Value = b.ToString(), Text = b.ToString() })
                                  .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(AddPrenotazioneModel addPrenotazioneModel)
        {
            if (!ModelState.IsValid || !Enum.TryParse<Sale>(addPrenotazioneModel.Sala, out Sale salaSelezionata) || !Enum.TryParse<Biglietto>(addPrenotazioneModel.TipoBiglietto, out Biglietto bigliettoSelezionato))
            {
                return RedirectToAction("Add");
            }

            

            var nuovaPren = new Prenotazione()
            {
                Id = Guid.NewGuid(),
                Nome = addPrenotazioneModel.Nome,
                Cognome = addPrenotazioneModel.Cognome,
                Sala = salaSelezionata,
                TipoBiglietto = bigliettoSelezionato,
            };
            prenotazione.Add(nuovaPren);

            return RedirectToAction("Index");
        }
    }
}
