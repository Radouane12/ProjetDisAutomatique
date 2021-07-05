using ProjetDistributeur.Core.Interface.Services;
using ProjetDistributeur.Core.Models;
using ProjetDistributeurWeb2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjetDistributeurWeb2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRecetteService recetteService;

        public HomeController(IRecetteService _recetteService)
        {
            recetteService = _recetteService;
        }



        public ActionResult Index()
        {
            return View(recetteService.GetAllRecette());
        }

        // GET: Recettes/CalculerPrixRecette/5
        public ActionResult CalculerPrixRecette(int? id)
        {
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Recette selectedRecette = recetteService.GetRecetteById((int)id);

            if (selectedRecette == null)
            {
                return HttpNotFound();
            }
            RecetteViewModel RecetteVM = new RecetteViewModel() { recette = selectedRecette, prix = recetteService.CalculerPrixVente(selectedRecette) };

            return View(RecetteVM);
        }
    }
}