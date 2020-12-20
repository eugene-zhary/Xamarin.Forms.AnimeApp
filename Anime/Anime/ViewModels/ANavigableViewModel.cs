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
    public abstract class ANavigableViewModel : INotifyPropertyChanged
    {
        protected INavigationService NavigationService { get; }

        protected ANavigableViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }


        public virtual Task Load()
        {
            return Task.CompletedTask;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void Set<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue)) {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
