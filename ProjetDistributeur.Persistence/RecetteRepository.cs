using ProjetDistributeur.Core.Interface.Repository;
using ProjetDistributeur.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDistributeur.Persistence
{
    public class RecetteRepository : IRecetteRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Cette méthode permet de recuperer toutes les recettes </returns>
        public List<Recette> GetAllRecette()
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

        public Recette GetRecetteById(int id)
        {
            return GetAllRecette().FirstOrDefault(w => w.IdRecette == id);
        }
    }



}
