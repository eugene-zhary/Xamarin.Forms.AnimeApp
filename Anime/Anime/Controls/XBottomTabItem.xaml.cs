using Sharpnado.Tabs;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Anime.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class XBottomTabItem : TabItem
    {
        public static readonly BindableProperty IconImageSourceProperty = BindableProperty.Create(
            nameof(IconImageSource),
            typeof(ImageSource),
            typeof(XBottomTabItem));

        public static readonly BindableProperty IconSizeProperty = BindableProperty.Create(
            nameof(IconSize),
            typeof(double),
            typeof(XBottomTabItem),
            defaultValue: 30D);

        public static readonly BindableProperty UnselectedIconColorProperty = BindableProperty.Create(
            nameof(UnselectedIconColor),
            typeof(Color),
            typeof(XBottomTabItem));


        private readonly bool _isInitialized = false;

        public XBottomTabItem()
        {
            InitializeComponent();
            _isInitialized = true;
        }

        [TypeConverter(typeof(ImageSourceConverter))]
        public ImageSource IconImageSource {
            get => (ImageSource)GetValue(IconImageSourceProperty);
            set => SetValue(IconImageSourceProperty, value);
        }

        public double IconSize {
            get => (double)GetValue(IconSizeProperty);
            set => SetValue(IconSizeProperty, value);
        }

        public Color UnselectedIconColor {
            get => (Color)GetValue(UnselectedIconColorProperty);
            set => SetValue(UnselectedIconColorProperty, value);
        }


        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (!_isInitialized) {
                return;
            }

            switch (propertyName) {
                case nameof(UnselectedIconColor):
                case nameof(SelectedTabColor):
                case nameof(IsSelected):
                    UpdateIconColor();
                    break;
            }
        }

        private void UpdateIconColor()
        {
            if (IsSelected) {
                Sharpnado.Tabs.Effects.ImageEffect.SetTintColor(Icon, SelectedTabColor);
            }
            else {
                Sharpnado.Tabs.Effects.ImageEffect.SetTintColor(Icon, UnselectedIconColor);
            }
        }

        protected override void OnBadgeChanged(BadgeView oldBadge)
        {
        }

    }
}