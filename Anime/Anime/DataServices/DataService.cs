using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Anime.DataServices
{
    public class DataService : IDataService
    {
        public string[] GetData(DataType type)
        {
            string[] result;
            using (SqlConnection connection = new SqlConnection(ServerInfo.ConnectionPath)) {
                connection.Open();

                using (SqlCommand command = new SqlCommand(ServerInfo.GetCommand(type), connection)) {
                    SqlDataReader data = command.ExecuteReader();
                    result = new string[0];
                    while (data.Read()) {
                        Array.Resize(ref result, result.Length + 1);

                        for (int i = 0; i < data.FieldCount; i++) {
                            if (data.GetName(i).Equals(ServerInfo.GetName(type))) {
                                result[result.Length - 1] = data[i].ToString();
                            }
                        }
                    }
                }

                connection.Close();
            }
            return result;
        }




        //// execute select query
        //private static async Task<object[,]> QuerySelect(string selectCommand, string connectionPath)
        //{
        //    object[,] result;

        //    using (SqlConnection connection = new SqlConnection(connectionPath)) {
        //        await connection.OpenAsync();

        //        using (SqlCommand command = new SqlCommand(selectCommand, connection)) {
        //            SqlDataReader data = await command.ExecuteReaderAsync();
        //            result = await ReadData(data);
        //        }
        //        connection.Close();
        //    }

        //    return result;
        //}

        //// read rows from data
        //private static async Task<object[,]> ReadData(SqlDataReader data)
        //{
        //    object[,] rows = new object[0, data.FieldCount];

        //    while (await data.ReadAsync()) {
        //        rows = ResizeArray(in rows, rows.GetLength(0) + 1, rows.GetLength(1));
        //        for (int i = 0; i < data.FieldCount; i++) {
        //            rows[rows.GetLength(0) - 1, i] = data.GetValue(i);
        //        }
        //    }

        //    return rows;
        //}

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
