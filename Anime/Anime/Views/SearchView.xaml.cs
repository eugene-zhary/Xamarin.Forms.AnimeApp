﻿using Anime.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Anime.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchView : ContentPage
    {
        public SearchView()
        {
            InitializeComponent();

            SearchViewModel vm = new SearchViewModel();
            vm.SelectionChangedEv += Vm_SelectionChangedEv;
            this.BindingContext = vm;
        }

        private void Vm_SelectionChangedEv(object sender, string e)
        {
            DisplayAlert("selected", e, "ok");
        }
    }
}