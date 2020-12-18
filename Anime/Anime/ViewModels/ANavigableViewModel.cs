using Anime.Navigable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace Anime.ViewModels
{
    public abstract class ANavigableViewModel : INotifyPropertyChanged
    {
        protected INavigationService NavigationService { get; }

        protected ANavigableViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }


        public virtual void Load() { }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged<T>(Expression<Func<T>> expression)
        {
            if (expression == null) {
                throw new ArgumentException("Getting property name from expression is not supported for this type");
            }
            if (!(expression is LambdaExpression lambda)) {
                throw new NotSupportedException("Getting property name from expression is not supported for this type");
            }
            if (lambda.Body is MemberExpression memberExpression) {
                RaisePropertyChanged(memberExpression.Member.Name);
                return;
            }
            var unary = lambda.Body as UnaryExpression;
            if (unary?.Operand is MemberExpression member) {
                RaisePropertyChanged(member.Member.Name);
                return;
            }

            throw new NotSupportedException("Getting property name from expression is not supported for this type");
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetAndRaise<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(property, value)) {
                return false;
            }
            property = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
    }
}
