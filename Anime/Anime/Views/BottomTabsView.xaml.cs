using Anime.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Anime.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BottomTabsView : ContentPage, IBindablePage
    {
        public BottomTabsView()
        {
            InitializeComponent();
            Switcher.SelectedIndex = 0;

        }
    }
}