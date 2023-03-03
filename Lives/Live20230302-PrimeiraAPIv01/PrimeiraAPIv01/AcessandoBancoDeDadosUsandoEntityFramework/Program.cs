using System;
using System.Data;
using System.Data.SqlClient;
using AcessandoBancoDeDadosUsandoEntityFramework.Data;

namespace ExampleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            // List brands from db context
            using (var db = new BikestoreContext())
            {
                foreach (var brand in db.Categories)
                {
                    Console.WriteLine(brand.CategoryName);
                }
            }

            Console.ReadKey();
        }
    }
}
