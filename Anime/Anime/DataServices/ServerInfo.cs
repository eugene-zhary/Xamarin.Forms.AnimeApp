using System;

namespace Anime.DataServices
{
    public enum DataType
    {
        Types,
        Genrs,
        Anime,
        History,
        User,

        UserName,
        UserSex,
        UserBDay,
        UserAboutMe,
        UserImgUrl
    };

    public static class ServerInfo
    {
        public static string ConnectionPath = "Data Source=SQL5053.site4now.net,1433;Initial Catalog=DB_A6BD74_zharydb;User Id=DB_A6BD74_zharydb_admin;Password=Eugene89Zhary31;";

        public static string GetProcSelect(DataType type)
        {
            switch (type) {
                case DataType.Types:
                    return "GetTypes";
                case DataType.Genrs:
                    return "GetGenres";
                case DataType.Anime:
                    return "GetAnime";
                case DataType.History:
                    return "GetHistory";
                case DataType.User:
                    return "GetUserInfo";
                default:
                    throw new Exception("error type");
            }
        }

        public static string GetProcUpdate(DataType type)
        {
            switch (type) {
                case DataType.UserName:
                    return "UpdateUserInfoName";
                case DataType.UserBDay:
                    return "UpdateUserInfoBday";
                case DataType.UserSex:
                    return "UpdateUserInfoSex";
                case DataType.UserAboutMe:
                    return "UpdateUserInfoAboutMe";
                case DataType.UserImgUrl:
                    return "UpdateUserImgPath";
                default:
                    throw new Exception("error type");
            }
        }
    }
}
