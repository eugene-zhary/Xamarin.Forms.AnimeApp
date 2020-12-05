using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace Anime
{
    public class Resolver
    {
        private static IContainer container;

        public static void Inititalize(IContainer container)
        {
            Resolver.container = container;
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}
