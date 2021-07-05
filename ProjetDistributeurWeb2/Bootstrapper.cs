using ProjetDistributeur.Core.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using Unity.Mvc5;
using ProjetDistributeur.Service.RecetteService;
using ProjetDistributeur.Core.Interface.Repository;
using ProjetDistributeur.Persistence;

namespace ProjetDistributeurWeb2
{
    public class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            System.Web.Mvc.DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here  
            //This is the important line to edit  
            container.RegisterType<IRecetteService, RecetteService>();
            container.RegisterType<IRecetteRepository, RecetteRepository>();


            RegisterTypes(container);
            return container;
        }
        public static void RegisterTypes(IUnityContainer container)
        {

        }
    }
}