using Anime.ViewModels;
using Anime.Views;
using System;
using System.Collections.Generic;

namespace Anime.Navigable
{
    public class ViewLocator : IViewLocator
    {
        private static readonly Dictionary<string, Type> ViewLocatorDictionary = new Dictionary<string, Type> {
            {nameof(BottomTabsViewModel), typeof(BottomTabsView) },
            {nameof(HomeViewModel), typeof(HomeView) },
            {nameof(SearchViewModel), typeof(SearchView) },
            {nameof(ProfileViewModel), typeof(ProfileView) },
        };


        public IBindablePage GetViewFor<TViewModel>() where TViewModel : ANavigableViewModel
        {
            var viewModel = DependencyContainer.Instance.GetInstance<TViewModel>();
            IBindablePage view = (IBindablePage)DependencyContainer.Instance.GetInstance(ViewLocatorDictionary[typeof(TViewModel).Name]);
            view.BindingContext = viewModel;
            return view;
        }

        public IBindablePage GetViewFor<TViewModel>(TViewModel viewModel, NavigationTransition transition) where TViewModel : ANavigableViewModel
        {
            var view = (IBindablePage)DependencyContainer.Instance.GetInstance(
                ViewLocatorDictionary[$"{viewModel.GetType().Name}+{transition}"]);
            view.BindingContext = viewModel;
            return view;
        }

        public Type GetViewTypeFor<TViewModel>() where TViewModel : ANavigableViewModel
        {
            return ViewLocatorDictionary[typeof(TViewModel).Name];
        }

        public Type GetViewTypeFor<TViewModel>(TViewModel viewModel, NavigationTransition transition) where TViewModel : ANavigableViewModel
        {
            return ViewLocatorDictionary[$"{viewModel.GetType().Name}+{transition}"];
        }
    }
}
