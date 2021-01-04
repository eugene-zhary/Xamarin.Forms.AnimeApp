using Anime.Models;
using Anime.Navigable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Anime.ViewModels
{
    public class AccountSettingsViewModel : ANavigableViewModel
    {
        public UserModel User { get; set; }
        public ObservableCollection<FieldModel> UserFields { get; set; }

        public FieldModel SelectedItem {
            set {
                if (value != null)
                    DisplayPrompt(value);
            }
        }

        public AccountSettingsViewModel(INavigationService navigationService) : base(navigationService)
        {
            User = new UserModel(1);

            UserFields = new ObservableCollection<FieldModel>() {
                new FieldModel{ FieldName = User.Name, Header = "Username"},
                new FieldModel{ FieldName = User.BDay.ToShortDateString(), Header = "BDay"},
                new FieldModel{ FieldName = User.Sex, Header = "Sex"},
                new FieldModel{ FieldName = User.AboutMe, Header = "About me"}
            };
        }

        void DisplayPrompt(FieldModel item)
        {
            switch (item.Header) {
                case "Username":
                    App.Current.MainPage.DisplayPromptAsync( title:item.Header, message: "edit username:", 
                        placeholder: item.FieldName, maxLength: 16,
                        cancel: "cancel",accept: "accept").GetAwaiter();
                    break;
                case "BDay":
                    App.Current.MainPage.DisplayPromptAsync(title: item.Header, message: "edit bday:",
                        placeholder: item.FieldName, maxLength: 12,
                        cancel: "cancel", accept: "accept").GetAwaiter();
                    break;
                case "Sex":
                    App.Current.MainPage.DisplayPromptAsync(title: item.Header, message: "change sex:",
                        placeholder: item.FieldName, maxLength: 32,
                        cancel: "cancel", accept: "accept").GetAwaiter();
                    break;
                case "About me":
                    App.Current.MainPage.DisplayPromptAsync(title: item.Header, message: "edit bio:",
                        placeholder: item.FieldName, maxLength: 128,
                        cancel: "cancel", accept: "accept").GetAwaiter();
                    break;

                default:
                    break;
            }
        }
    }
}
