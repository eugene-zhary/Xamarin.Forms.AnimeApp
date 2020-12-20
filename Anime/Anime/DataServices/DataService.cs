using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Anime.DataServices
{
    public enum DataType
    {
        AnimeTypes,
        AnimeGenrs,
    };

    public class DataService
    {
        public static async Task<object[,]> GetDataAsync(DataType type)
        {
            Task<object[,]> task = Task.Run(() => GetData(type));
            return await task;
        }

        public static object[,] GetData(DataType type)
        {
            object[,] result;
            using (SqlConnection connection = new SqlConnection(ServerInfo.ConnectionPath)) {
                connection.Open();
                using (SqlCommand command = new SqlCommand(ServerInfo.GetProc(type), connection)) {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader data = command.ExecuteReader();

                    result = new object[0, data.FieldCount];
                    while (data.Read()) {
                        result = ResizeArray(result, result.GetLength(0) + 1, result.GetLength(1));
                        for (int i = 0; i < data.FieldCount; i++) {
                            result[result.GetLength(0) - 1, i] = data.GetValue(i);
                        }
                    }
                }
                connection.Close();
            }
            return result;
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
