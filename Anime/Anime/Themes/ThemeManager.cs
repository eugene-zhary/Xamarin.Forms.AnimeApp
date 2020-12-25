using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Anime.Themes
{
    public static class ThemeManager
    {

        public static void ChangeTheme(double hue)
        {
            var appSource = App.Current.Resources;

            appSource["PrimaryColor"] =
                    Color.FromHsla(hue, 0.8, 0.4);

            appSource["SubColor"] =
                    Color.FromHsla(hue, 0.4, 0.8);

            appSource["BackColor"] =
                    Color.FromHsla(hue, 1, 0.04);

            appSource["FrontColor"] =
                    Color.FromHsla(hue, 1, 0.08);

            appSource["TabColor"] =
                    Color.FromHsla(hue, 1, 0.12);
        }


    }
}
