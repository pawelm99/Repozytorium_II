using System;
using System.Data.SqlClient;


namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            string connectionSTring = @"Data Source=DESKTOP-9SL4PUT;Initial Catalog=ZNorthwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=True";
            using var SqlConnection = new SqlConnection(connectionSTring);
            SqlConnection.Open();

            DBCrud dBCrud = new DBCrud();
            dBCrud.Read(SqlConnection);
            dBCrud.Insert(SqlConnection);
            dBCrud.Update(SqlConnection);
            dBCrud.Delete(SqlConnection);



            SqlConnection.Close();

        }
    }
}
