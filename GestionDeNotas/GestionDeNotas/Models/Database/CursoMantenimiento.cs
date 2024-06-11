using GestionDeNotas.Models.Acceso;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionDeNotas.Models.Database
{
    [Permiso(Roles = "Administrador")]

    public class CursoMantenimiento
    {
        public static List<Curso> GetCursos()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("SELECT c.codigocurso as 'codigo',c.carnetdocente as 'carnetDocente',CONCAT(p.nombres,p.apellidos) as 'Nombre completo',c.materia as 'materia',c.seccion as 'seccion',c.hora as 'hora', c.cantidadestudiante 'cantidad estudiante' FROM Curso c inner join Profesores p on p.carnet = c.carnetdocente", connection))
                    {

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Curso curso = new Curso()
                                {
                                    CodigoCurso = reader["codigo"].ToString(),
                                    CarnetDocente = reader["carnetDocente"].ToString(),
                                    CodigoMateria = reader["materia"].ToString(),
                                    Seccion = Int32.Parse(reader["seccion"].ToString()),
                                    Hora = reader["hora"].ToString(),
                                    CantidadPersonas = int.Parse(reader["cantidad estudiante"].ToString())
                                };
                                cursos.Add(curso);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return cursos;
        }

        public static Curso GetCurso(string codigo)
        {
            Curso cursos = new Curso();
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("SELECT c.codigocurso as 'codigo',c.carnetdocente as 'carnetDocente',CONCAT(p.nombres,p.apellidos) as 'Nombre completo',c.materia as 'materia',c.seccion as 'seccion',c.hora as 'hora' FROM Curso c inner join Profesores p on p.carnet = c.carnetdocente  where codigocurso = @codigo", connection))
                    {
                        cmd.Parameters.AddWithValue("@codigo",codigo);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                cursos.CodigoCurso = reader["codigo"].ToString();
                                    cursos.CarnetDocente = reader["carnetDocente"].ToString();
                                    cursos.CodigoMateria = reader["materia"].ToString();
                                    cursos.Seccion = Int32.Parse(reader["seccion"].ToString());
                                    cursos.Hora = reader["hora"].ToString();
                                
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return cursos;
        }

        public static void AddCurso(Curso curso)
        {
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("INSERT INTO Curso (codigocurso,carnetdocente,materia,seccion,hora) VALUES (@codigo,@carnet,@materia,@seccion,@hora)", connection))
                    {
                        cmd.Parameters.AddWithValue("@codigo", curso.CodigoCurso);
                        cmd.Parameters.AddWithValue("@carnet", curso.CarnetDocente);
                        cmd.Parameters.AddWithValue("@materia", curso.CodigoMateria);
                        cmd.Parameters.AddWithValue("@seccion", curso.Seccion);
                        cmd.Parameters.AddWithValue("@hora", curso.Hora);

                        cmd.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void UpdateCurso(Curso curso)
        {
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("UPDATE Curso SET carnetdocente = @carnet, materia = @materia, seccion = @seccion ,hora= @hora where codigocurso= @codigo", connection))
                    {
                        cmd.Parameters.AddWithValue("@codigo", curso.CodigoCurso);
                        cmd.Parameters.AddWithValue("@carnet", curso.CarnetDocente);
                        cmd.Parameters.AddWithValue("@materia", curso.CodigoMateria);
                        cmd.Parameters.AddWithValue("@seccion", curso.Seccion);
                        cmd.Parameters.AddWithValue("@hora", curso.Hora);

                        cmd.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void DeleteCurso(string codigo)
        {
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("DELETE FROM Curso where codigocurso = @codigo", connection))
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

        public static List<Curso> GetCursosByTeacher(string carnet)
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("SELECT c.codigocurso as 'codigo',c.carnetdocente as 'carnetDocente',CONCAT(p.nombres,p.apellidos) as 'Nombre completo',c.materia as 'materia',c.seccion as 'seccion',c.hora as 'hora' FROM Curso c inner join Profesores p on p.carnet = c.carnetdocente where c.carnetdocente = @carnetdocente", connection))
                    {
                        cmd.Parameters.AddWithValue("@carnetdocente", carnet);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Curso curso = new Curso()
                                {
                                    CodigoCurso = reader["codigo"].ToString(),
                                    CarnetDocente = reader["carnetDocente"].ToString(),
                                    CodigoMateria = reader["materia"].ToString(),
                                    Seccion = Int32.Parse(reader["seccion"].ToString()),
                                    Hora = reader["hora"].ToString()
                                };
                                cursos.Add(curso);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return cursos;
        }

        public static List<Curso> GetCursosByAlumno(string carnet)
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("SELECT c.codigocurso,c.materia,c.seccion,c.hora FROM Curso c inner join Matricula m on m.curso = c.codigocurso inner join Materia ma on ma.codigomateria = c.materia where m.alumno = @carnet", connection))
                    {
                        cmd.Parameters.AddWithValue("@carnet",carnet);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Curso curso = new Curso()
                                {
                                    CodigoCurso = reader["codigocurso"].ToString(),
                                    CodigoMateria = reader["materia"].ToString(),
                                    Seccion = Int32.Parse(reader["seccion"].ToString()),
                                    Hora = reader["hora"].ToString(),
                                };
                                cursos.Add(curso);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return cursos;
        }
    }
}