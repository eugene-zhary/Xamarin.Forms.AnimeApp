using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Anime.Controls
{
    public class FlexableView : FlexLayout
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            nameof(ItemsSource),
            typeof(IEnumerable),
            typeof(FlexableView),
            propertyChanged: OnItemsSourceChanged);

        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(
            nameof(ItemTemplate),
            typeof(DataTemplate),
            typeof(FlexableView));

        public IEnumerable ItemsSource {
            get => GetValue(ItemsSourceProperty) as IEnumerable;
            set => SetValue(ItemsSourceProperty, value);
        }

        public DataTemplate ItemTemplate {
            get => GetValue(ItemTemplateProperty) as DataTemplate;
            set => SetValue(ItemTemplateProperty, value);
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldVal, object newVal)
        {
            var layout = (FlexableView)bindable;
            layout.Children.Clear();

            if (newVal is IEnumerable newValue) {
                foreach (var item in newValue) {
                    layout.Children.Add(layout.CreateChildrenView(item));
                }
            }
        }

        private View CreateChildrenView(object item)
        {
            ItemTemplate.SetValue(BindableObject.BindingContextProperty, item);
            return ItemTemplate.CreateContent() as View;
        }
    }
}
