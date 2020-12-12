using Anime.Navigable;
using MetroLog;
using MetroLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Anime
{
    public class CoreEntryPoint
    {
        private static readonly Assembly ProjectAssembly = typeof(CoreEntryPoint).GetTypeInfo().Assembly;

        public async Task RegisterDependenciesAsync()
        {
            await Task.Run(() => RegisterDependencies());
        }

        public void RegisterDependencies()
        {
            var container = DependencyContainer.Instance;

            container.RegisterSingleton(() => new Lazy<NavigationPage>(() => (NavigationPage)Application.Current.MainPage));

            container.RegisterSingleton<IViewLocator, ViewLocator>();
            container.RegisterSingleton<INavigationService, FormsNavigationService>();

            //register all views by convention
            foreach (var pageType in ProjectAssembly.ExportedTypes.Where(
                                     type =>
                                     type.Namespace.StartsWith("Anime.Views") &&
                                     !type.GetTypeInfo().IsAbstract &&
                                     type.Name.EndsWith("View"))) {
                container.Register(pageType);
            }

            //register all view models by convention
            foreach (var viewModelType in ProjectAssembly.ExportedTypes.Where(
                                     type =>
                                     type.Namespace.StartsWith("Anime.ViewModels") &&
                                     !type.GetTypeInfo().IsAbstract &&
                                     type.Name.EndsWith("ViewModel"))) {
                container.Register(viewModelType);
            }

            InitializeLogTargets();
        }

        private void InitializeLogTargets()
        {
            var config = new LoggingConfiguration();
            config.AddTarget(LogLevel.Info, LogLevel.Fatal, new DebugTarget());
            LoggerFactory.Inititalize(config);
        }
    }
}
