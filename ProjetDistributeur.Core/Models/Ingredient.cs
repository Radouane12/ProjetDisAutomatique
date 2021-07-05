using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDistributeur.Core.Models
{
   public class Ingredient
    {
        public Ingredient(int recetteId, Produit produit, int amount)
        {
            RecetteId = recetteId;
            Produit = produit;
            Amount = amount;
        }

        public Ingredient( Produit produit, int amount)
        {
          
            Produit = produit;
            Amount = amount;
        }


        public int ProduitId { get; set; }
        public int RecetteId { get; set; }
        public int Amount { get; set; }

        public Produit Produit { get; set; }




    }

}
