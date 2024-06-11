using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GestionDeNotas.Models.Database
{
    
    public class Conexion
    {
        private static SqlConnection _connection;

        public static void Connection()
        {
            string _urlConexion = ConfigurationManager.ConnectionStrings["Conexion"].ToString();
            _connection = new SqlConnection(_urlConexion);

            //return _connection;
        }

        public static SqlConnection GetSqlConnection()
        {
            string _urlConexion = ConfigurationManager.ConnectionStrings["Conexion"].ToString();
            _connection = new SqlConnection(_urlConexion);

            return _connection;
        }
    }
}