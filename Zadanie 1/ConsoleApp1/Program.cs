using System;
using System.Data.SqlClient;


namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            using var SqlConnection = DBCrud.SQLConnection();
            DBCrud.SQLConnectOpen(SqlConnection);
            DBCrud dBCrud = new DBCrud();
            dBCrud.Read(SqlConnection);
            dBCrud.Insert(SqlConnection);
            dBCrud.Update(SqlConnection);
            dBCrud.Delete(SqlConnection);
            DBCrud.SQLConnectClose(SqlConnection);




        }
    }
}
