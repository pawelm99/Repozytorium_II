using System;
using System.Data.SqlClient;


namespace ConsoleApp1
{
    class Program
    {
        static void Read(SqlConnection SqlConnection)
        {

            var zapytanie = "Select * FROM dbo.Spedytorzy ";

            var command = new SqlCommand(zapytanie, SqlConnection);

            using var reader = command.ExecuteReader();
            Console.WriteLine("--------Nazwa Firm--------");
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(1));
            }
            reader.Close();
            Console.WriteLine();
        }

        static void Insert(SqlConnection SqlConnection)
        {
            Console.Write("Wpisz nazwe Firmy: ");
            var NazwaFirmy = Console.ReadLine();
            var insertSQL = $"INSERT INTO dbo.Spedytorzy (IDspedytora, NazwaFirmy) VALUES (@IDspe, @NazwFir)";

            var insertCommand = new SqlCommand(insertSQL, SqlConnection);
            Console.Write("Wpisz IDspedytora: ");

            var IdSpedytorRead = Console.ReadLine();
            bool resulat = int.TryParse(IdSpedytorRead, out int IdSpedytor);
            if (resulat)
            {
                insertCommand.Parameters.AddWithValue("@NazwFir", NazwaFirmy);
                insertCommand.Parameters.AddWithValue("@IDspe", IdSpedytor);
                insertCommand.ExecuteNonQuery();
                Console.WriteLine("Insert Succes");
            }
            else
                Console.WriteLine("Zla podana liczba IDSpedytora!");



        }
        static void Update(SqlConnection SqlConnection)
        {
            Console.Write("Wpisz nazwe Fimry którą chcesz edytowac: ");
            var NazwaFirmy = Console.ReadLine();

            var updateSQL = $"UPDATE dbo.Spedytorzy SET IDspedytora=@IDspe,NazwaFirmy=@NazwFir WHERE NazwaFirmy=@nazwa_firmy";
            var updateComannd = new SqlCommand(updateSQL, SqlConnection);
            updateComannd.Parameters.AddWithValue("@nazwa_firmy", NazwaFirmy);
            Console.Write("Wpisz Nową Nazwe Frimy: ");
            var NazwaFirmyRead = Console.ReadLine();
            updateComannd.Parameters.AddWithValue("@NazwFir", NazwaFirmyRead);
            Console.Write("Wpisz Nową Liczbe IDSpedytora: ");
            var liczba = Console.ReadLine();
            bool result2 = int.TryParse(liczba, out int nowa_IDSpedytora);
            if (result2)
            {
                updateComannd.Parameters.AddWithValue("@IDspe", nowa_IDSpedytora);


                Console.WriteLine("Update Succes");
            }
            else
                Console.WriteLine("Bledna nowa liczba idSpedytora!");

            updateComannd.ExecuteNonQuery();
        }


        static void Delete(SqlConnection SqlConnection)
        {

            Console.Write("Wpisz nazwe Fimry którą chcesz usunąć: ");
            var NazwaFirmy = Console.ReadLine();

            var deleteSQL = $"DELETE dbo.Spedytorzy WHERE NazwaFirmy=@nazwa_firmy";
            var deleteCommand = new SqlCommand(deleteSQL, SqlConnection);
            deleteCommand.Parameters.AddWithValue("@nazwa_firmy", NazwaFirmy);
            deleteCommand.ExecuteNonQuery();
            Console.WriteLine("Delete Succes");

        }
        static void Main(string[] args)
        {
            string connectionSTring = @"Data Source=DESKTOP-9SL4PUT;Initial Catalog=ZNorthwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=True";
            using var SqlConnection = new SqlConnection(connectionSTring);
            SqlConnection.Open();

            Read(SqlConnection);
            Insert(SqlConnection);
            Update(SqlConnection);
            Delete(SqlConnection);



            SqlConnection.Close();

        }
    }
}
