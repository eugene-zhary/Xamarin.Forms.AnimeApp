using System;
using System.Threading.Tasks;

namespace Anime.DataServices
{
    public enum DataType {
        AnimeTypes,
        AnimeGenrs
    };

    public interface IDataService
    {
        Task<string[]> GetData(DataType type);
    }

    public static class ServerInfo
    {
        public static string ConnectionPath = "Data Source=SQL5053.site4now.net,1433;Initial Catalog=DB_A6BD74_zharydb;User Id=DB_A6BD74_zharydb_admin;Password=Eugene89Zhary31;";

        public static string GetCommand(DataType type)
        {
            switch (type) {
                case DataType.AnimeTypes:
                    return "SELECT * FROM [Types];";
                case DataType.AnimeGenrs:
                    return "SELECT * FROM [Genrs];";
                default:
                    throw new Exception("error type");
            }
        }

        public static string GetName(DataType type)
        {
            switch (type) {
                case DataType.AnimeTypes:
                    return "TypeName";
                case DataType.AnimeGenrs:
                    return "GenreName";
                default:
                    throw new Exception("error type");
            }
        }
    }
}
