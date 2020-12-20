using System;

namespace Anime.DataServices
{
    public static class ServerInfo
    {
        public static string ConnectionPath = "Data Source=SQL5053.site4now.net,1433;Initial Catalog=DB_A6BD74_zharydb;User Id=DB_A6BD74_zharydb_admin;Password=Eugene89Zhary31;";

        public static string GetProc(DataType type)
        {
            switch (type) {
                case DataType.Types:
                    return "GetTypes";
                case DataType.Genrs:
                    return "GetGenres";
                case DataType.Anime:
                    return "GetAnime";
                default:
                    throw new Exception("error type");
            }
        }
    }
}
