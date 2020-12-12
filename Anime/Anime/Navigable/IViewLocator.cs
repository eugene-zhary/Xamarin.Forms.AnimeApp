using Anime.ViewModels;
using Anime.Views;
using System;

namespace Anime.Navigable
{
    /// <summary>
    /// Service responsible for locating the correct view from the ViewModel infos.
    /// The service is currently also responsible for the creation of the view and the view model if needed.
    /// </summary>
    public interface IViewLocator
    {
        // Builds the view matching the given view model type.
        // Builds the view model and bind it to the created view.
        // Loads the view model.
        IBindablePage GetViewFor<TViewModel>()
            where TViewModel : ANavigableViewModel;

        // Builds the view matching the given [view model type + transition].
        // Binds the view model instance to the created view.
        IBindablePage GetViewFor<TViewModel>(TViewModel viewModel, NavigationTransition transition)
            where TViewModel : ANavigableViewModel;

        // Gets the view type matching the given view model.
        Type GetViewTypeFor<TViewModel>()
            where TViewModel : ANavigableViewModel;

        // Gets the view type matching the given view model and transition.
        Type GetViewTypeFor<TViewModel>(TViewModel viewModel, NavigationTransition transition)
            where TViewModel : ANavigableViewModel;
    }
}
