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
            throw new NotImplementedException();
        }

        // GET: Recettes/CalculerPrixRecette/5
        public ActionResult CalculerPrixRecette(int? id)
        {
            throw new NotImplementedException();
        }
    }
}