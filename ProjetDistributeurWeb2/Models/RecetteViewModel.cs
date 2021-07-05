using ProjetDistributeur.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetDistributeurWeb2.Models
{
    public class RecetteViewModel
    {
        public Recette recette { get; set; }
        public decimal prix { get; set; }
    }
}