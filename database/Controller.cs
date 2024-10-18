using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq; 
using Dapper;
using static Order_Flow.database.Controller;

namespace Order_Flow.database
{
    public class Controller
    {
        public class Order
        {
            public int id { get; set; }
            public string client { get; set; }
            public string locate { get; set; } 
            public string productkey { get; set; }
            public string contact { get; set; } 
            public string status { get; set; }
            public string dateproductpost { get; set; } 
        }

        public List<Order> Get()
        {
            using (var connection = new DBConnection())
            {
                if (connection.Connection == null)
                {
                    Console.WriteLine("A conexão com o banco de dados não foi estabelecida.");
                    return new List<Order>();
                }

                string query = @"SELECT * FROM orderflowtable;";
                var orders = connection.Connection.Query<Order>(query).ToList();
                        
                Console.WriteLine($"Número de trabalhadores retornados: {orders.Count}");
                                
                return orders;
            }
        }

        public bool DeleteWorker(int id)
        {
            using (var connection = new DBConnection())
            {
                if (connection.Connection == null)
                {
                    Console.WriteLine("A conexão com o banco de dados não foi estabelecida.");
                    return false;
                }


                string checkQuery = @"SELECT COUNT(*) FROM worker WHERE id = @Id;";
                int count = connection.Connection.ExecuteScalar<int>(checkQuery, new { Id = id });

                if (count == 0)
                {
                    return false;
                }

                // Exclui o trabalhador
                string deleteQuery = @"DELETE FROM worker WHERE id = @Id;";
                connection.Connection.Execute(deleteQuery, new { Id = id });
                return true;
            }
        }
    }
}
