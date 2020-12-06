using Anime.Models;
using Anime.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Anime.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();

            HomeViewModel vm = new HomeViewModel();
            vm.SelectionChangedEv += Vm_SelectionChangedEv;
            BindingContext = vm;

        }

        private void Vm_SelectionChangedEv(object sender, string e)
        {
            DisplayAlert("selected", e, "ok");
        }

    }
}