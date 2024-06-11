using GestionDeNotas.Models.Acceso;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace GestionDeNotas.Models.Database
{
    [Permiso(Roles = "Administrador")]

    public class DocenteMantenimiento
    {
        public static List<Profesor> GetProfesores()
        {
            List<Profesor> profesores = new List<Profesor>();
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("SELECT carnet,nombres,apellidos,tipodocente as 'Tipo Docente' FROM Profesores", connection))
                    {
                    
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Profesor teacher = new Profesor()
                                {
                                    Carnet = reader["carnet"].ToString(),
                                    Nombres = reader["nombres"].ToString(),
                                    Apellidos = reader["apellidos"].ToString(),
                                    TipoDocente = reader["Tipo Docente"].ToString()
                                };
                                profesores.Add(teacher);
                            }
                        }
                    }
                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return profesores;
        }

        public static Profesor GetProfesor(string carnet)
        {
            Profesor teacher = new Profesor();
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("SELECT carnet,nombres,apellidos,tipodocente as 'Tipo Docente' FROM Profesores where carnet = @carnet", connection))
                    {
                        cmd.Parameters.AddWithValue("@carnet",carnet);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                teacher.Carnet = reader["carnet"].ToString();
                                teacher.Nombres = reader["nombres"].ToString();
                                teacher.Apellidos = reader["apellidos"].ToString();
                                teacher.TipoDocente = reader["Tipo Docente"].ToString();
                                
                            
                            }
                        }
                    }
                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return teacher;
        }

        public static void AddProfesor(Profesor profesor)
        {
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("INSERT INTO Profesores (carnet,nombres,apellidos,tipodocente) VALUES (@carnet,@nombres,@apellidos,@tipodocente)", connection))
                    {
                        cmd.Parameters.AddWithValue("@carnet", profesor.Carnet);
                        cmd.Parameters.AddWithValue("@nombres", profesor.Nombres);
                        cmd.Parameters.AddWithValue("@apellidos", profesor.Apellidos);
                        cmd.Parameters.AddWithValue("@tipodocente", profesor.TipoDocente);

                        cmd.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void UpdateProfesor(Profesor profesor)
        {
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("UPDATE Profesores SET nombres = @nombres, apellidos = @apellidos, tipodocente = @tipodocente where carnet = @carnet", connection))
                    {
                        cmd.Parameters.AddWithValue("@carnet", profesor.Carnet);
                        cmd.Parameters.AddWithValue("@nombres", profesor.Nombres);
                        cmd.Parameters.AddWithValue("@apellidos", profesor.Apellidos);
                        cmd.Parameters.AddWithValue("@tipodocente", profesor.TipoDocente);

                        cmd.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void DeleteProfesor(string carnet)
        {
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("DELETE FROM Profesores where carnet = @carnet", connection))
                    {
                        cmd.Parameters.AddWithValue("@carnet",carnet);
                        cmd.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public List<string> GetCarnets()
        {
            List<string> carnets = new List<string>();
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("SELECT carnet FROM Profesores", connection))
                    {

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string carnet = reader["carnet"].ToString();
                                carnets.Add(carnet);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return carnets;
        }
    }
}