using System;
using Npgsql;

namespace Order_Flow.database
{
  public class DBConnection : IDisposable
    {
        public NpgsqlConnection Connection { get; private set; }

        public DBConnection()
        {
            try
            {
                Connection = new NpgsqlConnection("Server=localhost;Port=5432;Database=oderflow;User Id=postgres;Password=1100;");
                Connection.Open();
                Console.WriteLine("Conexão aberta com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao abrir a conexão: {ex.Message}");
                Connection = null;
            }
        }

        public void Dispose()
        {
            try
            {
                Connection?.Dispose();
                Console.WriteLine("Conexão fechada com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao fechar a conexão: {ex.Message}");
            }
        }
    }
}
