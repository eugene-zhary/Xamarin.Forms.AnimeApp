using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Anime.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        //public virtual void Load() {}

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
