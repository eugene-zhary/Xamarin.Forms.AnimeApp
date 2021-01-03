using System;
using System.Collections.Generic;
using System.Text;
using Anime.Navigable;

namespace Anime.ViewModels
{
    public class ColorSettingsViewModel: BaseViewModel
    {
        private double hueValue;
        public double HueValue {
            get => hueValue;
            set {
                if (hueValue != value) {
                    Set(ref hueValue, value);
                    App.SetHue(Math.Round(value: hueValue, digits: 2));
                }
            }
        }

        public ColorSettingsViewModel()
        {
            this.hueValue = App.GetHue();
        }


    }
}
