﻿using System;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Anime.Behaviors
{
    public class FlexLayoutItemTappedBehavior : Behavior<FlexLayout>
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(FlexLayoutItemTappedBehavior), defaultBindingMode: BindingMode.OneWay);

        public static readonly BindableProperty ParamaterProperty =
            BindableProperty.Create(nameof(Paramater), typeof(object), typeof(FlexLayoutItemTappedBehavior), defaultBindingMode: BindingMode.OneWay);

        public ICommand Command {
            get => (ICommand)this.GetValue(CommandProperty);
            set => this.SetValue(CommandProperty, value);
        }

        public object Paramater {
            get => (object)this.GetValue(ParamaterProperty);
            set => this.SetValue(ParamaterProperty, value);
        }

        protected override void OnAttachedTo(FlexLayout bindable)
        {
            base.OnAttachedTo(bindable);

            if (bindable.BindingContext != null) {
                this.BindingContext = bindable.BindingContext;
            }

            bindable.BindingContextChanged += this.OnFlexLayoutBindingChanged;
            bindable.ChildAdded += this.OnFlexLayoutChildAdded;
        }

        protected override void OnDetachingFrom(FlexLayout bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.BindingContextChanged -= this.OnFlexLayoutBindingChanged;
            bindable.ChildAdded -= this.OnFlexLayoutChildAdded;

            foreach (var child in bindable.Children) {
                if (child is View childView && childView.GestureRecognizers.Any()) {
                    var tappedGestureRecognizers = childView.GestureRecognizers.Where(x => x is TapGestureRecognizer).Cast<TapGestureRecognizer>();
                    foreach (var tapGestureRecognizer in tappedGestureRecognizers) {
                        tapGestureRecognizer.Tapped -= this.OnItemTapped;
                        childView.GestureRecognizers.Remove(tapGestureRecognizer);
                    }
                }
            }
        }

        private void OnFlexLayoutBindingChanged(object sender, EventArgs e)
        {
            if (sender is FlexLayout flexLayout) {
                this.BindingContext = flexLayout.BindingContext;
            }
        }

        private void OnFlexLayoutChildAdded(object sender, ElementEventArgs args)
        {
            if (args.Element is View view) {
                var tappedGestureRecognizer = new TapGestureRecognizer();
                tappedGestureRecognizer.Tapped += this.OnItemTapped;

                view.GestureRecognizers.Add(tappedGestureRecognizer);
            }
        }

        private void OnItemTapped(object sender, EventArgs e)
        {
            if (sender is BindableObject bindable && this.Command != null && this.Command.CanExecute(null)) {
                
                object resolvedParameter = Paramater ?? e;

                if (Command.CanExecute(resolvedParameter)) {
                    this.Command.Execute(bindable.BindingContext);
                }
            }
        }
    }
}

