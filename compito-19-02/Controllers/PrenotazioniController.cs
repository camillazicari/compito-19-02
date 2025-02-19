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
               TipoBiglietto = Biglietto.Ridotto
           }

        };

        public IActionResult Index()
        {
            List<Prenotazione> prenotazioniSalaNord = new List<Prenotazione>();
            List<Prenotazione> prenotazioniSalaEst = new List<Prenotazione>();
            List<Prenotazione> prenotazioniSalaSud = new List<Prenotazione>();

            List<Prenotazione> ridottiSalaNord = new List<Prenotazione>();
            List<Prenotazione> ridottiSalaEst = new List<Prenotazione>();
            List<Prenotazione> ridottiSalaSud = new List<Prenotazione>();


            foreach (var prenotazione in prenotazione)
            {
                if (prenotazione.Sala == Sale.SalaNord)
                {
                    prenotazioniSalaNord.Add(prenotazione);
                    if (prenotazione.TipoBiglietto == Biglietto.Ridotto)
                    {
                        ridottiSalaNord.Add(prenotazione);
                    }
                }
                else if (prenotazione.Sala == Sale.SalaEst)
                {
                    prenotazioniSalaEst.Add(prenotazione);
                    if (prenotazione.TipoBiglietto == Biglietto.Ridotto)
                    {
                        ridottiSalaEst.Add(prenotazione);
                    }
                }
                else
                {
                    prenotazioniSalaSud.Add(prenotazione);
                    if (prenotazione.TipoBiglietto == Biglietto.Ridotto)
                    {
                        ridottiSalaSud.Add(prenotazione);
                    }
                }
            }


            var prenot = new PrenotazioneViewModel()
            {
                TotaleNord = prenotazioniSalaNord.Count(),
                RidottiNord = ridottiSalaNord.Count(),

                TotaleEst = prenotazioniSalaEst.Count(),
                RidottiEst = ridottiSalaEst.Count(),

                TotaleSud = prenotazioniSalaSud.Count(),
                RidottiSud = ridottiSalaSud.Count(),

                Prenotazione = prenotazione
            };

            

            return View(prenot);
        }

        public IActionResult Add()
        {
            ViewBag.SaleDisponibili = Enum.GetValues(typeof(Sale))
                                  .Cast<Sale>()
                                  .Select(s => new SelectListItem
                                  {
                                      Value = s.ToString(),  
                                      Text = s.ToString()
                                  })
                                  .ToList();

            ViewBag.BigliettiDisponibili = Enum.GetValues(typeof(Biglietto))
                                    .Cast<Biglietto>()
                                    .Select(b => new SelectListItem
                                    {
                                        Value = b.ToString(),
                                        Text = b.ToString()
                                    })
                                    .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(AddPrenotazioneModel addPrenotazioneModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Add");
            }



            var nuovaPren = new Prenotazione()
            {
                Id = Guid.NewGuid(),
                Nome = addPrenotazioneModel.Nome,
                Cognome = addPrenotazioneModel.Cognome,
                Sala = addPrenotazioneModel.Sala,
                TipoBiglietto = addPrenotazioneModel.TipoBiglietto,
            };
            prenotazione.Add(nuovaPren);

            return RedirectToAction("Index");
        }
    }
}
