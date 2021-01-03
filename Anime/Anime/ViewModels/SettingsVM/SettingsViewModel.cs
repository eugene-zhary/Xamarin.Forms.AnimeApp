using Anime.Navigable;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Anime.ViewModels
{
    public class SettingsViewModel : ANavigableViewModel
    {
        private double hueValue;
        public double HueValue {
            get => hueValue;
            set {
                if(hueValue != value) {
                    Set(ref hueValue, value);
                    App.SetHue(Math.Round(value: hueValue, digits: 2));
                }
            }
        }

        public SettingsViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.hueValue = App.GetHue();
        }

    }
}
