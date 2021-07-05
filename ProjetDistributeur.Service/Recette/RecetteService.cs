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

        public const decimal marge = 0.30M;

        public RecetteService(IRecetteRepository _recetteRepository)
        {
            recetteRepository = _recetteRepository;
        }
        //public RecetteService()
        //{

        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recette"></param>
        /// <returns>Calculer le prix de la boisson = prix coutant des recettes + marge de 30% </returns>
        public decimal CalculerPrixVente(Recette recette)
        {
            decimal prix = 0M;
            foreach (var i in recette.Ingredients)
            {
                prix += i.Produit.Price * i.Amount;
            }
            prix += prix * marge;
            return Math.Round(prix, 2);
        }

        public List<Recette> GetAllRecette()
        {

            return recetteRepository.GetAllRecette();
        }

        public Recette GetRecetteById(int id)
        {
            return recetteRepository.GetRecetteById(id);
        }
    }
}
