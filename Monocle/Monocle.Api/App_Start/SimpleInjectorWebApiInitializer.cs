using System.Web.Http;
using Monocle.Api;
using Monocle.Repository;
using Monocle.Repository.Interfaces;
using Monocle.Repository.Repository;
using Monocle.Services.Interfaces;
using Monocle.Services.Services;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

[assembly: WebActivator.PostApplicationStartMethod(typeof(SimpleInjectorWebApiInitializer), "Initialize")]

namespace Monocle.Api
{
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<IRepositoryConfiguration, RepositoryConfiguration>();
            container.Register<IStoryService, StoryService>();
            container.Register<IStoryRepository, StoryRepository>();
            container.Register<IPostService, PostService>();
            container.Register<IPostRepository, PostRepository>();
        }
    }
}