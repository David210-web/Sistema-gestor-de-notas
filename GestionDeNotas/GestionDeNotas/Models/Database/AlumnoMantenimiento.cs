using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionDeNotas.Models.Database
{
    public class AlumnoMantenimiento
    {
        public static List<Alumnos> GetAlumnos()
        {
            List<Alumnos> alumnos = new List<Alumnos>();
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("SELECT carnet,nombres,apellidos,genero FROM Alumnos", connection))
                    {

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Alumnos alumnos1 = new Alumnos()
                                {
                                    Carnet = reader["carnet"].ToString(),
                                    Nombres = reader["nombres"].ToString(),
                                    Apellidos = reader["apellidos"].ToString(),
                                    Genero = reader["genero"].ToString()
                                };
                                alumnos.Add(alumnos1);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return alumnos;
        }

        public static Alumnos GetAlumno(string carnet)
        {
            Alumnos alumnos = new Alumnos();
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("SELECT carnet,nombres,apellidos,genero FROM Alumnos where carnet = @carnet", connection))
                    {
                        cmd.Parameters.AddWithValue("@carnet", carnet);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                alumnos.Carnet = reader["carnet"].ToString();
                                alumnos.Nombres = reader["nombres"].ToString();
                                alumnos.Apellidos = reader["apellidos"].ToString();
                                alumnos.Genero = reader["genero"].ToString();


                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return alumnos;
        }

        public static void AddAlumnos(Alumnos alumnos)
        {
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("INSERT INTO Alumnos (carnet,nombres,apellidos,genero) VALUES (@carnet,@nombres,@apellidos,@genero)", connection))
                    {
                        cmd.Parameters.AddWithValue("@carnet", alumnos.Carnet);
                        cmd.Parameters.AddWithValue("@nombres", alumnos.Nombres);
                        cmd.Parameters.AddWithValue("@apellidos", alumnos.Apellidos);
                        cmd.Parameters.AddWithValue("@genero", alumnos.Genero);

                        cmd.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void UpdateAlumnos(Alumnos alumnos)
        {
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("UPDATE Alumnos SET nombres = @nombres, apellidos = @apellidos, genero = @genero where carnet = @carnet", connection))
                    {
                        cmd.Parameters.AddWithValue("@carnet", alumnos.Carnet);
                        cmd.Parameters.AddWithValue("@nombres", alumnos.Nombres);
                        cmd.Parameters.AddWithValue("@apellidos", alumnos.Apellidos);
                        cmd.Parameters.AddWithValue("@genero", alumnos.Genero);

                        cmd.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void DeleteAlumnos(string carnet)
        {
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("DELETE FROM Alumnos where carnet = @carnet", connection))
                    {
                        cmd.Parameters.AddWithValue("@carnet", carnet);
                        cmd.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static List<Alumnos> GetAlumnosByCurso(string codigo)
        {
            List<Alumnos> alumnos = new List<Alumnos>();
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("SELECT a.carnet,a.nombres,a.apellidos,a.genero FROM Alumnos a inner join Matricula m on m.alumno = a.carnet where m.curso = @codigo", connection))
                    {
                        cmd.Parameters.AddWithValue("@codigo",codigo);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Alumnos alumnos1 = new Alumnos()
                                {
                                    Carnet = reader["carnet"].ToString(),
                                    Nombres = reader["nombres"].ToString(),
                                    Apellidos = reader["apellidos"].ToString(),
                                    Genero = reader["genero"].ToString()
                                };
                                alumnos.Add(alumnos1);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return alumnos;
        }

    }
}