using Anime.Models;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace Anime.DataServices
{
    public static class DataService
    {
        private static readonly SqlConnection connection = new SqlConnection(ServerInfo.ConnectionPath);

        public static object GetData(DataType type, object user_id = null)
        {
            object data;
            connection.Open();

            switch (type) {
                case DataType.Genrs:
                    data = GetCategory(type);
                    break;

                case DataType.Types:
                    data = GetCategory(type);
                    break;

                case DataType.Anime:
                    data = GetAnime(type);
                    break;

                case DataType.History:
                    data = GetAnime(type, user_id);
                    break;

                case DataType.User:
                    data = GetUserInfo(type, user_id);
                    break;

                default:
                    throw new Exception("error type");
            }

            connection.Close();
            return data;
        }

        private static object GetUserInfo(DataType type, object value = null)
        {
            var result = new UserModel();

            using (SqlCommand command = new SqlCommand(ServerInfo.GetProcSelect(type), connection)) {
                command.CommandType = CommandType.StoredProcedure;

                if ( value != null) {
                    command.Parameters.Add("@user_id", SqlDbType.Int);
                    command.Parameters["@user_id"].Value = value;
                }

                SqlDataReader data = command.ExecuteReader();

                while (data.Read()) {
                    //0 - name
                    //1 - bday
                    //2 - sex
                    //3 - about me
                    //4 - img url

                    result.Name = data.GetValue(0).ToString();
                    result.BDay = DateTime.Parse(data.GetValue(1).ToString());
                    result.Sex = data.GetValue(2).ToString();
                    result.AboutMe = data.GetValue(3).ToString();
                    result.ImgUrl = data.GetValue(4).ToString();
                }
            }

            return result;
        }

        private static object GetAnime(DataType type, object value = null)
        {
            var result = new ObservableCollection<AnimeModel>();

            using (SqlCommand command = new SqlCommand(ServerInfo.GetProcSelect(type), connection)) {
                command.CommandType = CommandType.StoredProcedure;

                if (value != null) {
                    command.Parameters.Add("@user_id", SqlDbType.Int);
                    command.Parameters["@user_id"].Value = value;
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

        private static object GetCategory(DataType type)
        {
            var result = new ObservableCollection<CategoryModel>();

            using (SqlCommand command = new SqlCommand(ServerInfo.GetProcSelect(type), connection)) {
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader data = command.ExecuteReader();

                while (data.Read()) {
                    //0 - Name
                    result.Add(new CategoryModel() { Name = data.GetValue(0).ToString() });
                }
            }

            return result;
        }

        public static void UpdateData(DataType type, int user_id, object NewValue)
        {
            connection.Open();

            switch (type) {
                case DataType.UserName:
                    UpdateUserData(type, user_id, "@name", NewValue, SqlDbType.NVarChar);
                    break;

                case DataType.UserBDay:
                    UpdateUserData(type, user_id, "@bday", NewValue, SqlDbType.Date);
                    break;

                case DataType.UserSex:
                    UpdateUserData(type, user_id, "@sex", NewValue, SqlDbType.NVarChar);
                    break;

                case DataType.UserAboutMe:
                    UpdateUserData(type, user_id, "@about_me", NewValue, SqlDbType.NVarChar);
                    break;

                case DataType.UserImgUrl:
                    UpdateUserData(type, user_id, "@img_path", NewValue, SqlDbType.NVarChar);
                    break;

                default:
                    throw new Exception("error type");
            }

            connection.Close();
        }

        private static void UpdateUserData(DataType type, int user_id, string paramName, object newValue, SqlDbType paramType)
        {
            using (SqlCommand command = new SqlCommand(ServerInfo.GetProcUpdate(type), connection)) {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@user_id", SqlDbType.Int);
                command.Parameters.Add(paramName, paramType);

                command.Parameters["@user_id"].Value = user_id;
                command.Parameters[paramName].Value = newValue;


                if (!(command.ExecuteNonQuery() > 0))
                    throw new Exception("insert fail");
            }
        }
    }
}
