using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Anime.Controls
{
    public class XFrame : Frame
    {
        public static readonly BindableProperty MultiCornerRadiusProperty =
            BindableProperty.Create(nameof(MultiCornerRadius), typeof(CornerRadius), typeof(XFrame));

        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create(nameof(BorderWidth), typeof(int), typeof(XFrame));

        public XFrame()
        {
            base.CornerRadius = 0;
        }

        public CornerRadius MultiCornerRadius {
            get => (CornerRadius)GetValue(MultiCornerRadiusProperty);
            set => SetValue(MultiCornerRadiusProperty, value);
        }

        public int BorderWidth {
            get => (int)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }
    }
}
