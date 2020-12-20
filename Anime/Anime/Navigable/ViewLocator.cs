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
            {nameof(TopViewModel),typeof(TopView) },
            {nameof(HistoryViewModel), typeof(HistoryView) },
            {nameof(UserInfoViewModel),typeof(UserInfoView) },
            {nameof(GenresViewModel),typeof(GenresTypesView) },
            {nameof(TypesViewModel),typeof(GenresTypesView) }
        };

        public IBindablePage GetViewFor<TViewModel>() where TViewModel : ANavigableViewModel
        {
            var viewModel = DependencyContainer.Instance.GetInstance<TViewModel>();
            IBindablePage view = (IBindablePage)DependencyContainer.Instance.GetInstance(ViewLocatorDictionary[typeof(TViewModel).Name]);
            view.BindingContext = viewModel;
            return view;
        }

        public Type GetViewTypeFor<TViewModel>() where TViewModel : ANavigableViewModel
        {
            return ViewLocatorDictionary[typeof(TViewModel).Name];
        }

    }
}
