using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjetDistributeur.Core.Interface.Repository;
using ProjetDistributeur.Core.Interface.Services;
using ProjetDistributeur.Core.Models;
using ProjetDistributeur.Persistence;
using ProjetDistributeur.Service.RecetteService;

namespace ProjetDistributeur.Test
{
    [TestClass]
    public class RecetteRepositoryTest


    {
        [TestMethod]
        public void Tester_GetAllRecette()


        {
            var recetteRepository = new RecetteRepository();
            var result = recetteRepository.GetAllRecette();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Recette>));
        }

        [TestMethod]
        public void Tester_Repo_GetRecetteById_Avec_Id_Existant()


        {

            var recetteRepository = new RecetteRepository();
            var recette = recetteRepository.GetRecetteById(2);
            Assert.IsNotNull(recette);
            Assert.AreEqual("Allonge", recette.Name);


        }

        [TestMethod]
        public void Tester_Service_GetRecetteById_Avec_Id_Not_Existant()


        {
            var recetteRepository = new RecetteRepository();
            var recette = recetteRepository.GetRecetteById(-1);
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
