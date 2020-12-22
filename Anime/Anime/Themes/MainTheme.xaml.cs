using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Anime.Themes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTheme : ResourceDictionary
    {
        public MainTheme()
        {
            InitializeComponent();

            double hue = 0.8;

            this["PrimaryColor"] = 
                Color.FromHsla(hue, 0.8, 0.4);

            this["SubColor"] =  
                Color.FromHsla(hue, 0.4, 0.8);

            this["BackColor"] = 
                Color.FromHsla(hue, 1, 0.04);

            this["FrontColor"] = 
                Color.FromHsla(hue, 1, 0.08);

            this["TabColor"] = 
                Color.FromHsla(hue, 1, 0.12);
        }
    }
}