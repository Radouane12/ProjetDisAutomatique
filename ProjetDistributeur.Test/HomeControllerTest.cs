using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjetDistributeur.Core.Interface.Services;
using ProjetDistributeur.Core.Models;
using ProjetDistributeurWeb2.Controllers;
using ProjetDistributeurWeb2.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace ProjetDistributeur.Test
{
    [TestClass]
    public class HomeControllerTest


    {
        [TestMethod]
        public void Index_GetAllRecette()
        {


            var recetteServiceMock = new Mock<IRecetteService>();

            recetteServiceMock.Setup(serv => serv.GetAllRecette()).Returns((GetTestRecettes()));
            var controller = new HomeController(recetteServiceMock.Object);

            var viewResult = controller.Index() as ViewResult;

            Assert.IsNotNull(viewResult);

            var recettes = viewResult.ViewData.Model as List<Recette>;

            Assert.AreEqual(5, recettes.Count);

        }



        [TestMethod]
        public void Calculer_PrixRecette_AvecId_Existant()
        {


            var recetteServiceMock = new Mock<IRecetteService>();

            recetteServiceMock.Setup(serv => serv.GetRecetteById(2)).Returns(GetTestRecettes()[1]);
            var controller = new HomeController(recetteServiceMock.Object);

            var viewResult = controller.CalculerPrixRecette(2) as ViewResult;

            Assert.IsNotNull(viewResult);
            var recetteVM = viewResult.ViewData.Model as RecetteViewModel;
            Assert.AreEqual("Allonge", recetteVM.recette.Name);

        }


        [TestMethod]
        public void Calculer_PrixRecette_AvecId_Non_Existant()
        {


            var recetteServiceMock = new Mock<IRecetteService>();
            recetteServiceMock.Setup(serv => serv.GetRecetteById(2)).Returns((Recette)null);
            var controller = new HomeController(recetteServiceMock.Object);


            ActionResult actionResult = controller.CalculerPrixRecette(2);

           
            Assert.IsInstanceOfType(actionResult, typeof(HttpNotFoundResult));

        }

        [TestMethod]
        public void Calculer_PrixRecette_AvecId_Null()
        {

            var recetteServiceMock = new Mock<IRecetteService>();
            var controller = new HomeController(recetteServiceMock.Object);

            ActionResult actionResult = controller.CalculerPrixRecette(null);

            //assert
            var expectedResulat = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Assert.AreEqual((actionResult as HttpStatusCodeResult).StatusCode, expectedResulat.StatusCode);

        }



        private List<Recette> GetTestRecettes()
        {
            Produit cafe = new Produit("Café", 1M);
            Produit sucre = new Produit("Sucre", 0.1M);
            Produit creme = new Produit("Crème", 0.5M);
            Produit the = new Produit("The", 2M);
            Produit eau = new Produit("Eau", 0.2M);
            Produit chocolat = new Produit("Chocolat", 1M);
            Produit lait = new Produit("Lait", 0.4M);

            List<Recette> recettes = new List<Recette>() {

            new Recette(1, "Expresso", new Ingredient(cafe, 1), new Ingredient(eau, 1)),
            new Recette(2, "Allonge", new Ingredient(cafe, 1), new Ingredient(eau, 2)),
            new Recette(3, "Capuccino", new Ingredient(cafe, 1), new Ingredient(chocolat, 1), new Ingredient(eau, 1), new Ingredient(creme, 1)),
            new Recette(4, "Chocolat", new Ingredient(chocolat, 3), new Ingredient(lait, 2), new Ingredient(eau, 1), new Ingredient(sucre, 1)),
            new Recette(5, "The", new Ingredient(the, 1), new Ingredient(eau, 2))
            };
            return recettes;


        }



    }
}
