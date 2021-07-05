using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjetDistributeur.Core.Interface.Repository;
using ProjetDistributeur.Core.Interface.Services;
using ProjetDistributeur.Core.Models;
using ProjetDistributeur.Service.RecetteService;

namespace ProjetDistributeur.Test
{
    [TestClass]
    public class RecetteServiceTest


    {

        static Produit cafe = new Produit("Café", 1M);
        static Produit sucre = new Produit("Sucre", 0.1M);
        static Produit creme = new Produit("Crème", 0.5M);
        static Produit the = new Produit("The", 2M);
        static Produit eau = new Produit("Eau", 0.2M);
        static Produit chocolat = new Produit("Chocolat", 1M);
        static Produit lait = new Produit("Lait", 0.4M);


        static decimal prixExpresso = 1.56M;
        static decimal prixCafeSeul = 1.3M;
        static decimal prixChocolat = 5.33M;



        [TestMethod]
        public void Tester_Prix_Recette_avec_0_ingredient()


        {
            var recetteRepositoryMock = new Mock<IRecetteRepository>();
            var recetteService = new RecetteService(recetteRepositoryMock.Object);

            Recette r_boissonsSansIngredient = new Recette(1, "BoissonSansIngrediet");
            Assert.AreEqual(0, recetteService.CalculerPrixVente(r_boissonsSansIngredient));

        }

        [TestMethod]
        public void Tester_Prix_Recette_avec_1_ingredient()


        {
            var recetteRepositoryMock = new Mock<IRecetteRepository>();
            var recetteService = new RecetteService(recetteRepositoryMock.Object);

            Recette r_cafeSeul = new Recette(1, "Expresso", new Ingredient(cafe, 1));
            Assert.AreEqual(prixCafeSeul, recetteService.CalculerPrixVente(r_cafeSeul));
        }


        [TestMethod]
        public void Tester_Prix_Recette_avec_2_ingredients()


        {
            var recetteRepositoryMock = new Mock<IRecetteRepository>();
            var recetteService = new RecetteService(recetteRepositoryMock.Object);
            Recette r_expresso = new Recette(1, "Expresso", new Ingredient(cafe, 1), new Ingredient(eau, 1));
            Assert.AreEqual(prixExpresso, recetteService.CalculerPrixVente(r_expresso));
        }

        [TestMethod]
        public void Tester_Prix_Recette_avec_plusieurs_Ingredients()


        {

            var recetteRepositoryMock = new Mock<IRecetteRepository>();
            var recetteService = new RecetteService(recetteRepositoryMock.Object);


            Recette r_chocolat = new Recette(1, "Chocolat", new Ingredient(chocolat, 3),
                new Ingredient(lait, 2), new Ingredient(sucre, 1), new Ingredient(eau, 1));
            Assert.AreEqual(recetteService.CalculerPrixVente(r_chocolat), prixChocolat);
        }


        [TestMethod]
        public void Tester_Service_GetAllRecette()


        {

            var recetteRepositoryMock = new Mock<IRecetteRepository>();
            var recetteService = new RecetteService(recetteRepositoryMock.Object);
            recetteRepositoryMock.Setup(repo => repo.GetAllRecette()).Returns((GetTestRecettes()));
            var result = recetteService.GetAllRecette();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Recette>));
            Assert.AreEqual(5, result.Count);
        }

        [TestMethod]
        public void Tester_Service_GetAllRecette_IsNull()


        {
            var recetteRepositoryMock = new Mock<IRecetteRepository>();
            recetteRepositoryMock.Setup(serv => serv.GetAllRecette()).Returns((List<Recette>)null);
            var recetteService = new RecetteService(recetteRepositoryMock.Object);


            var result = recetteService.GetAllRecette();

            Assert.IsNull(result);


        }
        
        [TestMethod]
        public void Tester_Service_GetRecetteById_Avec_Id_Existant()


        {

            var recetteRepositoryMock = new Mock<IRecetteRepository>();
            var recetteService = new RecetteService(recetteRepositoryMock.Object);
            recetteRepositoryMock.Setup(repo => repo.GetRecetteById(2)).Returns((GetTestRecettes()[1]));

            var recette = recetteService.GetRecetteById(2);

            Assert.IsNotNull(recette);
           
            Assert.AreEqual("Allonge", recette.Name);

           
        }

        [TestMethod]
        public void Tester_Service_GetRecetteById_Avec_Id_Not_Existant()


        {
            var recetteRepositoryMock = new Mock<IRecetteRepository>();
            var recetteService = new RecetteService(recetteRepositoryMock.Object);
            recetteRepositoryMock.Setup(repo => repo.GetRecetteById(2)).Returns((Recette)null);
            var recette = recetteService.GetRecetteById(2);
            Assert.IsNull(recette);

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
