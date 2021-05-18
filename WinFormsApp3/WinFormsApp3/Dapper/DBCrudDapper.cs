﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3
{
    class DBCrudDapper
    {
        private IDbConnection _connection;
        public DBCrudDapper(string ConnectionString)
        {
            _connection = new SqlConnection(ConnectionString);

        }
        public IEnumerable<ObszarZagrozony> GetArea()
        {
            return _connection.Query<ObszarZagrozony>("SELECT * FROM dane.ObszarZagrozony");
        }

    }
}