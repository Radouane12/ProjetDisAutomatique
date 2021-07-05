using ProjetDistributeur.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDistributeur.Core.Interface.Services
{
    public interface IRecetteService
    {
        decimal CalculerPrixVente(Recette recette);
        List<Recette> GetAllRecette();
        Recette GetRecetteById(int id);
    }
}
