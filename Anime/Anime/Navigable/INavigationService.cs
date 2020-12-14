using Anime.ViewModels;
using Anime.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Anime.Navigable
{
    public interface INavigationService
    {
        // Navigates to the bindable page matching the given navigable view model type.
        Task NavigateToAsync<TViewModel>(object parameter = null, bool modalNavigation = false, bool clearStack = false, bool animated = true)
            where TViewModel : ANavigableViewModel;
        
        // Navigation from menu means: reset the stack, and then add the new page.
        Task NavigateFromMenuToAsync<TViewModel>()
            where TViewModel : ANavigableViewModel;

        // Close the current bindable page.
        Task<IBindablePage> NavigateBackAsync(object parameter = null);
    }
}
