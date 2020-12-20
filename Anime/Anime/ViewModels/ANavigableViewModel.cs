using Anime.Navigable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Anime.ViewModels
{
    public abstract class ANavigableViewModel : BaseViewModel
    {
        protected INavigationService NavigationService { get; }

        protected ANavigableViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
    }
}
