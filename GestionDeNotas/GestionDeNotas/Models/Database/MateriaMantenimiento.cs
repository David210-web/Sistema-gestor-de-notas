using GestionDeNotas.Models.Acceso;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionDeNotas.Models.Database
{
    [Permiso(Roles = "Administrador")]

    public class MateriaMantenimiento
    {
        public static List<Materia> GetMaterias()
        {
            List<Materia> materia = new List<Materia>();
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("SELECT codigomateria,nombre from Materia", connection))
                    {

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Materia materia1= new Materia()
                                {
                                    CodigoMateria = reader["codigomateria"].ToString(),
                                    Nombre = reader["nombre"].ToString(),
                                    
                                };
                                materia.Add(materia1);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return materia;
        }

        public static Materia GetMateria(string codigo)
        {
            Materia materia = new Materia();
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("SELECT codigomateria,nombre from Materia where codigomateria = @codigo", connection))
                    {
                        cmd.Parameters.AddWithValue("@codigo", codigo);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                materia.CodigoMateria= reader["codigomateria"].ToString();
                                materia.Nombre = reader["nombre"].ToString();
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return materia;
        }

        public static void AddMateria(Materia materia)
        {
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("INSERT INTO Materia (codigomateria,nombre) VALUES (@codigomateria,@nombre)", connection))
                    {
                        cmd.Parameters.AddWithValue("@codigomateria", materia.CodigoMateria);
                        cmd.Parameters.AddWithValue("@nombre", materia.Nombre);

                        cmd.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void UpdateMateria(Materia materia)
        {
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("UPDATE Materia SET nombre = @nombre where codigomateria =  @codigo", connection))
                    {
                        cmd.Parameters.AddWithValue("@codigo", materia.CodigoMateria);
                        cmd.Parameters.AddWithValue("@nombre", materia.Nombre);

                        cmd.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void DeleteMateria(string codigo)
        {
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("DELETE FROM Materia where codigomateria = @codigo", connection))
                    {
                        cmd.Parameters.AddWithValue("@codigo", codigo);
                        cmd.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}