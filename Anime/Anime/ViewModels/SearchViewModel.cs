using Anime.Models;
using Anime.Navigable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Data.SqlClient;

namespace Anime.ViewModels
{
    public class SearchViewModel : ANavigableViewModel
    {
        public event EventHandler<string> SelectionChangedEv;

        public ObservableCollection<string> AnimeTypes { get; set; }
        public ObservableCollection<string> AnimeGenres { get; set; }

        public SearchViewModel(INavigationService navigationService) : base(navigationService)
        {
            InitializeCollections();

            //this.AnimeTypes = new ObservableCollection<string>() {
            //    "Кодомо",
            //    "Сёнэн",
            //    "Сёдзё",
            //    "Сэйнэн",
            //    "Дзё",
            //    "OAV/OVA",
            //    "ТВ-сериал",
            //    "ТВ-фильм",
            //    "короткометражные ",
            //};
            //this.AnimeGenres = new ObservableCollection<string>() {
            //    "Боевик",
            //    "Повседневность",
            //    "Романтика",
            //    "Паропанк",
            //    "Киберпанк",
            //    "Спокон",
            //    "Сэнтай",
            //    "Меха",
            //    "Научная фантастика",
            //    "Драма",
            //    "История",
            //    "Комедия",
            //    "Сказка",
            //    "Детектив",
            //    "Мистика",
            //};
        }

        public ICommand TappedOnItem => new Command((item) => {
            if (item is string title)
                SelectionChangedEv?.Invoke(this, title);
        });

        private void InitializeCollections()
        {
            string connection_path = "Data Source=SQL5053.site4now.net,1433;Initial Catalog=DB_A6BD74_zharydb;User Id=DB_A6BD74_zharydb_admin;Password=Eugene89Zhary31;";
            var types = QuerySelect("SELECT * FROM [Types];", connection_path);
            var genres = QuerySelect("SELECT * FROM [Genrs];", connection_path);


            this.AnimeTypes = new ObservableCollection<string>();
            this.AnimeGenres = new ObservableCollection<string>();

            for (int i = 0; i < types.GetLength(0); i++) {
                AnimeTypes.Add(types[i,1].ToString());
            }
            for (int i = 0; i < genres.GetLength(0); i++) {
                AnimeGenres.Add(genres[i,1].ToString());
            }
        }

        private static object[,] QuerySelect(in string selectCommand, in string connectionPath)
        {
            object[,] result;

            //подключение к бд
            using (SqlConnection connection = new SqlConnection(connectionPath)) {
                connection.Open();

                using (SqlCommand command = new SqlCommand(selectCommand, connection)) {
                    //получение данных
                    SqlDataReader data = command.ExecuteReader();
                    result = ReadData(data);
                }

                connection.Close();
            }

            return result;
        }

        private static object[,] ReadData(SqlDataReader data)
        {
            object[,] rows = new string[0, data.FieldCount];

            //строки с данными
            while (data.Read()) {
                rows = ResizeArray(in rows, rows.GetLength(0) + 1, rows.GetLength(1));
                for (int i = 0; i < data.FieldCount; i++) {
                    rows[rows.GetLength(0) - 1, i] = (data.GetValue(i) == DBNull.Value) ? "NULL" : data.GetValue(i);
                }
            }
            return rows;
        }

        private static T[,] ResizeArray<T>(in T[,] original, int rows, int cols)
        {
            T[,] newArray = new T[rows, cols];
            int minRows = Math.Min(rows, original.GetLength(0));
            int minCols = Math.Min(cols, original.GetLength(1));

            for (int i = 0; i < minRows; i++)
                for (int j = 0; j < minCols; j++)
                    newArray[i, j] = original[i, j];
            return newArray;
        }
    }
}
