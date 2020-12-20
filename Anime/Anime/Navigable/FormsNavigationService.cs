using Anime.ViewModels;
using Anime.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Anime.Navigable
{
    public class FormsNavigationService : INavigationService
    {
        //The forms navigation service
        private readonly Lazy<NavigationPage> lazyFormsNavigation;
        //The view locator
        private readonly IViewLocator viewLocator;

        public FormsNavigationService(Lazy<NavigationPage> lazyFormsNavigation, IViewLocator viewLocator)
        {
            this.lazyFormsNavigation = lazyFormsNavigation;
            this.viewLocator = viewLocator;
        }

        //The navigation page
        private NavigationPage NavigationPage => lazyFormsNavigation.Value;
        //The forms navigation
        private INavigation FormsNavigation => lazyFormsNavigation.Value.Navigation;


        public async Task<IBindablePage> NavigateBackAsync()
        {
            var page = (IBindablePage)await NavigationPage.PopAsync();
            return page;
        }

        public async Task NavigateFromMenuToAsync<TViewModel>() where TViewModel : ANavigableViewModel
        {
            var view = viewLocator.GetViewFor<TViewModel>();
            await NavigationPage.PushAsync((Page)view);
            //((ANavigableViewModel)view.BindingContext).Load();

            foreach (var page in FormsNavigation
                                            .NavigationStack
                                            .Take(FormsNavigation.NavigationStack.Count -1)
                                            .Skip(1)) {
                FormsNavigation.RemovePage(page);
            }
        }

        public async Task NavigateToAsync<TViewModel>(bool modalNavigation = false, bool clearStack = false, bool animated = true) where TViewModel : ANavigableViewModel
        {
            if (clearStack) {
                var viewType = viewLocator.GetViewTypeFor<TViewModel>();
                var rootPage = FormsNavigation.NavigationStack.First();
                if(viewType != rootPage.GetType()) {
                    var newRootView = (Page)viewLocator.GetViewFor<TViewModel>();

                    //make the new view the root of our navigation stack
                    FormsNavigation.InsertPageBefore(newRootView, rootPage);
                    rootPage = newRootView;
                }
                //Then we want to go back to root page and clear the stack
                await NavigationPage.PopToRootAsync(animated);
                //((ANavigableViewModel)rootPage.BindingContext).Load();
                return;
            }
        }
    }
}
