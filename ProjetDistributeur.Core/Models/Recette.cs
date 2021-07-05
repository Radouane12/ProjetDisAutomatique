using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDistributeur.Core.Models
{
    public class Recette
    {

        public Recette(int idRecette, string name, params Ingredient[] ingredients)

        {
            Name = name;
            IdRecette = idRecette;

            // Préparer la liste des ingrédients pour chaque recette  --  Ingredient est définit par IdProduit , IdRecette et Amount 
            Ingredients = new List<Ingredient>();
            foreach (var i in ingredients)
            {
                Ingredients.Add(new Ingredient(idRecette, i.Produit, i.Amount));
            }
        }

        public IList<Ingredient> Ingredients { get; set; }
        public int IdRecette { get; set; }
        public string Name { get; set; }

    }
}
