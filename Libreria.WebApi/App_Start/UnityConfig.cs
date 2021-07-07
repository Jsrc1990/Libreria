using Libreria.BackBusiness;
using Libreria.BackBusiness.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Libreria.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IAutorBackBusiness, AutorBackBusiness>();
            container.RegisterType<ILibroBackBusiness, LibroBackBusiness>();
            container.RegisterType<IGeneroBackBusiness, GeneroBackBusiness>();
            container.RegisterType<ICiudadBackBusiness, CiudadBackBusiness>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}