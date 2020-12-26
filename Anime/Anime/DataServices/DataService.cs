using Anime.Models;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Anime.DataServices
{
    public static class DataService
    {
        public static object GetData(DataType type, object user_id = null)
        {
            using (SqlConnection connection = new SqlConnection(ServerInfo.ConnectionPath)) {
                connection.Open();


                switch (type) {
                    case DataType.Genrs:
                        return GetCategory(connection, DataType.Genrs);

                    case DataType.Types:
                        return GetCategory(connection, DataType.Types);

                    case DataType.Anime:
                        return GetAnime(connection, DataType.Anime);

                    case DataType.History:
                        //user id
                        return GetAnime(connection, DataType.History, "@user_id", user_id);

                    case DataType.User:
                        //user id
                        return GetUserInfo(connection, DataType.User, "@user_id", user_id);

                    default:
                        throw new Exception("error type");
                }
            }
        }

        private static object GetUserInfo(in SqlConnection connection, DataType type, string name, object value)
        {
            var result = new UserModel();

            using (SqlCommand command = new SqlCommand(ServerInfo.GetProc(type), connection)) {
                command.CommandType = CommandType.StoredProcedure;

                if (name != null && value != null) {
                    command.Parameters.Add(name, SqlDbType.Int);
                    command.Parameters[name].Value = value;
                }

                SqlDataReader data = command.ExecuteReader();

                while (data.Read()) {
                    //0 - name
                    //1 - bday
                    //2 - sex
                    //3 - about me
                    //4 - img url
                    result = new UserModel() {
                        Name = data.GetValue(0).ToString(),
                        BDay = DateTime.Parse(data.GetValue(1).ToString()),
                        Sex = data.GetValue(2).ToString(),
                        AboutMe = data.GetValue(3).ToString(),
                        ImgUrl = data.GetValue(4).ToString()
                    };
                }
            }

            return result;
        }

        private static object GetAnime(in SqlConnection connection, DataType type, string name = null, object value = null)
        {
            var result = new ObservableCollection<AnimeModel>();

            using (SqlCommand command = new SqlCommand(ServerInfo.GetProc(type), connection)) {
                command.CommandType = CommandType.StoredProcedure;

                if (name != null && value != null) {
                    command.Parameters.Add(name, SqlDbType.Int);
                    command.Parameters[name].Value = value;
                }

                SqlDataReader data = command.ExecuteReader();

                while (data.Read()) {
                    //0 - title
                    //1 - rating
                    //2 - url
                    result.Add(new AnimeModel() {
                        Title = data.GetValue(0).ToString(),
                        Rating = data.GetValue(1).ToString(),
                        ImgUrl = data.GetValue(2).ToString()
                    });
                }
            }

            return result;
        }

        private static object GetCategory(in SqlConnection connection, DataType type)
        {
            var result = new ObservableCollection<CategoryModel>();

            using (SqlCommand command = new SqlCommand(ServerInfo.GetProc(type), connection)) {
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader data = command.ExecuteReader();

                while (data.Read()) {
                    //0 - Name
                    result.Add(new CategoryModel() { Name = data.GetValue(0).ToString() });
                }
            }

            return result;
        }

    }
}
