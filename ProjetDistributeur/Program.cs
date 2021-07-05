using ProjetDistributeur.Core.Interface.Repository;
using ProjetDistributeur.Core.Interface.Services;
using ProjetDistributeur.Core.Models;
using ProjetDistributeur.Persistence;
using ProjetDistributeur.Service.RecetteService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDistributeur
{
    class Program
    {
    


        static  void Main(string[] args)
        {
            IRecetteRepository recetteRepository = new RecetteRepository();
            IPriceService priceService = new PriceService(recetteRepository);
            
        
            var menu = priceService.GetAllRecette();


            decimal prix = priceService.CalculerPrixVente(menu.);

            Console.WriteLine(prix);

            Console.ReadKey();
           




        }

      


        
    }
}
