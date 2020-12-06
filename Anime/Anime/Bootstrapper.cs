using Anime.Behaviors;
using Anime.ViewModels;
using Anime.Views;
using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Anime
{
    public class Bootstrapper
    {
        public static void Init()
        {
            var builder = new ContainerBuilder();

            //todo: services

            var currentAssembly = Assembly.GetExecutingAssembly();
            //all views
            builder.RegisterAssemblyTypes(currentAssembly).Where(x => x.Name.EndsWith("View", StringComparison.Ordinal));
            //all view models
            builder.RegisterAssemblyTypes(currentAssembly).Where(x => x.Name.EndsWith("ViewModel", StringComparison.OrdinalIgnoreCase));
            //all behaviors
            builder.RegisterAssemblyTypes(currentAssembly).Where(x => x.Name.EndsWith("Behavior", StringComparison.OrdinalIgnoreCase));

            var container = builder.Build();
            Resolver.Inititalize(container);
        }

    }
}
