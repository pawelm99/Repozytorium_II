using System;
using System.Data.SqlClient;


namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {

            DBCrud dBCrud = new DBCrud();
            dBCrud.SQLConnection();
            dBCrud.SQLConnectOpen();
            dBCrud.Read();
            dBCrud.Insert();
            dBCrud.Update();
            dBCrud.Delete();
            dBCrud.SQLConnectClose();




        }
    }
}
