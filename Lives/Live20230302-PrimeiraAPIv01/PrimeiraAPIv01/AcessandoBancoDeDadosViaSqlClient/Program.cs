using System;
using System.Data;
using System.Data.SqlClient;

namespace ExampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                try
                {
                    Console.WriteLine("Digite a sentença SQL a ser executada no banco de dados BikeStore:");
                    var dados = ExecutarSql("select * from brands");
                    Console.WriteLine();

                    foreach (DataColumn column in dados.Tables[0].Columns)
                    {
                        Console.Write($"{column.ColumnName}\t\t");
                    }

                    foreach (DataRow row in dados.Tables[0].Rows)
                    {
                        Console.Write("\n");
                        foreach (DataColumn column in dados.Tables[0].Columns)
                        {
                            Console.Write($"{row[column.ColumnName]}\t\t");
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Deseja executar outra SQL?");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                    Console.WriteLine("Vamos de novo ...");
                }

                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }
        }
        
        static DataSet ExecutarSql(string sqlQuery)
        {
            // Define a string de conexão com o banco de dados
            string connectionString = "Data Source=.; Initial Catalog=bikestore; User ID=charles;Password=015580; MultipleActiveResultSets=True;TrustServerCertificate=True;";

            // Cria um objeto SqlConnection usando a string de conexão
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Cria um objeto SqlCommand usando a sentença SQL e a conexão
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Cria um objeto DataSet para armazenar os resultados da consulta
                    DataSet dataSet = new DataSet();

                    // Cria um objeto SqlDataAdapter para preencher o DataSet com os resultados da consulta
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        // Abre a conexão com o banco de dados
                        connection.Open();

                        // Preenche o DataSet com os resultados da consulta
                        dataAdapter.Fill(dataSet);

                        // Fecha a conexão com o banco de dados
                        connection.Close();
                    }

                    return dataSet;
                }
            }
        }
        
    }
}
