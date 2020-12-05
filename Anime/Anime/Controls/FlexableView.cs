﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Anime.Controls
{
    public class FlexableView : FlexLayout
    {
        private DataTemplate itemsTemplate;
        public DataTemplate ItemsTemplate {
            get => itemsTemplate;
            set {
                itemsTemplate = value;
                MainThread.BeginInvokeOnMainThread(() => Generate());
            }
        }

        public static BindableProperty ItemsSourceProperty = 
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<object>), typeof(FlexableView),
                propertyChanged: (bindable, oldValue, newValue) => {
                    var repeater = (FlexableView)bindable;
                    if (repeater.itemsTemplate == null)
                        return;
                    MainThread.BeginInvokeOnMainThread(() => repeater.Generate());
                });

        public IEnumerable<object> ItemsSource {
            get => GetValue(ItemsSourceProperty) as IEnumerable<object>;
            set => SetValue(ItemsSourceProperty, value);
        }


        private void Generate()
        {
            this.Children.Clear();

            if (ItemsSource == null) {
                return;
            }

            foreach (var item in ItemsSource) {
                if (itemsTemplate.CreateContent() is View view) {
                    view.BindingContext = item;
                    Children.Add(view);
                }
                else {
                    return;
                }
            }
        }
    }
}