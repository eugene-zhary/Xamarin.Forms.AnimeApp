using Xamarin.Forms;

namespace Anime.Controls
{
    public class XEntry : Entry
    {
        public static readonly BindableProperty XHighlightColorProperty
            = BindableProperty.Create(nameof(XHighlightColor), typeof(Color), typeof(XEntry));

        public static readonly BindableProperty XHandleColorProperty
            = BindableProperty.Create(nameof(XHandleColor), typeof(Color), typeof(XEntry));

        public static readonly BindableProperty XTintColorProperty
            = BindableProperty.Create(nameof(XTintColor), typeof(Color), typeof(XEntry));

        public static readonly BindableProperty XCornerRadiusProperty
            = BindableProperty.Create(nameof(XCornerRadius), typeof(int), typeof(XEntry), 0);

        public static readonly BindableProperty XBorderThicknessProperty
            = BindableProperty.Create(nameof(XBorderThickness), typeof(int), typeof(XEntry), 0);

        public static readonly BindableProperty XPaddingProperty
            = BindableProperty.Create(nameof(XPadding), typeof(Thickness), typeof(XEntry), new Thickness(5));


        public Color XHighlightColor {
            get => (Color)GetValue(XHighlightColorProperty);
            set => SetValue(XHighlightColorProperty, value);
        }

        public Color XHandleColor {
            get => (Color)GetValue(XHandleColorProperty);
            set => SetValue(XHandleColorProperty, value);
        }

        public Color XTintColor {
            get => (Color)GetValue(XTintColorProperty);
            set => SetValue(XTintColorProperty, value);
        }

        public int XCornerRadius {
            get => (int)GetValue(XCornerRadiusProperty);
            set => SetValue(XCornerRadiusProperty, value);
        }

        public int XBorderThickness {
            get => (int)GetValue(XBorderThicknessProperty);
            set => SetValue(XCornerRadiusProperty, value);
        }
        
        public Thickness XPadding {
            get => (Thickness)GetValue(XPaddingProperty);
            set => SetValue(XCornerRadiusProperty, value);
        }
    }
}
