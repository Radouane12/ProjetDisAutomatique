using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetDistributeur.Core.Interface.Repository;
using ProjetDistributeur.Core.Interface.Services;
using ProjetDistributeur.Core.Models;

namespace ProjetDistributeur.Service.RecetteService
{
    public class RecetteService : IRecetteService
    {
        private readonly IRecetteRepository recetteRepository;

   

        public RecetteService(IRecetteRepository _recetteRepository)
        {
            recetteRepository = _recetteRepository;
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recette"></param>
        /// <returns>Calculer le prix de la boisson = prix coutant des recettes + marge de 30% </returns>
        public decimal CalculerPrixVente(Recette recette)
        {
            throw new NotImplementedException();
        }

        public List<Recette> GetAllRecette()
        {

            throw new NotImplementedException();
        }

        public Recette GetRecetteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
