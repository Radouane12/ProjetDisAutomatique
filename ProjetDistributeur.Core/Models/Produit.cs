using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDistributeur.Core.Models
{
   public class Produit
    {
        public Produit(string name, decimal price)
        {
           // IdProduit = idProduit;
            Name = name;
            Price = price;
        }
        public int IdProduit { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

     
    }
}
