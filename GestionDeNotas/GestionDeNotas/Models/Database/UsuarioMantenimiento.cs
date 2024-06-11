using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionDeNotas.Models.Database
{
    public class UsuarioMantenimiento
    {
        public static int Logearse(Usuarios user)
        {
            using (var connection = Conexion.GetSqlConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand("sp_verificarCuenta", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@carnet", user.Carnet);
                    cmd.Parameters.AddWithValue("@pass", user.Password);

                    return Int32.Parse(cmd.ExecuteScalar().ToString());
                }
            }
        }

        public static void AñadirEstudiante(Usuarios usuario,string rol)
        {
            using(var connection = Conexion.GetSqlConnection())
            {
                connection.Open();
                using(var cmd = new SqlCommand("INSERT INTO Usuarios (carnet,password,rol) values (@carnet,@password,@rol)"))
                {
                    cmd.Parameters.AddWithValue("@carnet",usuario.Carnet);
                    cmd.Parameters.AddWithValue("@password", usuario.Password);
                    cmd.Parameters.AddWithValue("@rol", rol);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static string ObtenerRol(string carnet)
        {
            string rol;
            using (var connection = Conexion.GetSqlConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand("sp_GetRol",connection))
                {
                    cmd.Parameters.AddWithValue("@carnet", carnet);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    rol = cmd.ExecuteScalar().ToString();
                }
            }
            return rol;
        }

    }
}