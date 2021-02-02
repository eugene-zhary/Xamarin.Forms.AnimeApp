
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Anime.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountSettingsView : ContentView
    {
        public AccountSettingsView()
        {
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            settings_list.SelectedItem = null;
        }
    }
}