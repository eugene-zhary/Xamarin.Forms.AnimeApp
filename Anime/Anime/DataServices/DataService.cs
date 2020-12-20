using Anime.Models;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Anime.DataServices
{
    public enum DataType
    {
        Types,
        Genrs,
        Anime,
        
    };

    public class DataService
    {
        private static ObservableCollection<CategoryModel> GetCategory(DataType type, in SqlConnection connection)
        {
            var result = new ObservableCollection<CategoryModel>();

            using (SqlCommand command = new SqlCommand(ServerInfo.GetProc(type), connection)) {

                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader data = command.ExecuteReader();

                while (data.Read()) {
                    for (int i = 0; i < data.FieldCount; i++) {
                        result.Add(new CategoryModel() { Name = data.GetValue(i).ToString() });
                    }
                }
            }

            return result;
        }


        public static object GetData(DataType type)
        {
            object result;

            using (SqlConnection connection = new SqlConnection(ServerInfo.ConnectionPath)) {
                connection.Open();

                switch (type) {
                    case DataType.Genrs:
                        result = GetCategory(DataType.Genrs, connection);
                        break;

                    case DataType.Types:
                        result = GetCategory(DataType.Types, connection);
                        break;

                    default:
                        throw new Exception("error type");
                }

                connection.Close();
            }

            return result;
        }



        //private static T[,] ResizeArray<T>(in T[,] original, int rows, int cols)
        //{
        //    T[,] newArray = new T[rows, cols];
        //    int minRows = Math.Min(rows, original.GetLength(0));
        //    int minCols = Math.Min(cols, original.GetLength(1));

        //    for (int i = 0; i < minRows; i++)
        //        for (int j = 0; j < minCols; j++)
        //            newArray[i, j] = original[i, j];
        //    return newArray;
        //}
    }
}
