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

            throw new NotImplementedException();


        }

        public Recette GetRecetteById(int id)
        {
            throw new NotImplementedException();
        }
    }



}
