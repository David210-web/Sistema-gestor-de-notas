using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionDeNotas.Models.Database
{
    public class NotasMantenimiento
    {
        public static void AddNotas(Notas notas)
        {
            using(SqlConnection conn = Conexion.GetSqlConnection())
            {
                try
                {
                    conn.Open();
                    using(SqlCommand cmd = new SqlCommand("INSERT INTO Notas (alumno,materia,notaN1,notaN2,notaN3) VALUES (@alumno,@materia,@notaN1,@notaN2,@notaN3)",conn))
                    {
                        cmd.Parameters.AddWithValue("@alumno",notas.CarnetAlumno);
                        cmd.Parameters.AddWithValue("@materia",notas.CodigoMateria);
                        cmd.Parameters.AddWithValue("@notaN1", notas.Nota1);
                        cmd.Parameters.AddWithValue("@notaN2", notas.Nota2);
                        cmd.Parameters.AddWithValue("@notaN3",notas.Nota3);
                        cmd.ExecuteNonQuery();
                    }
                }catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

        }
        public static List<Notas> VerNotas(string carnet)
        {
            List<Notas> notas = new List<Notas>();
            using (SqlConnection conn = Conexion.GetSqlConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Notas WHERE alumno = @carnet", conn))
                    {
                        cmd.Parameters.AddWithValue("@carnet", carnet);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Notas notas1 = new Notas()
                                {
                                    Id = Int32.Parse(reader["id"].ToString()),
                                    CarnetAlumno = reader["alumno"].ToString(),
                                    CodigoMateria = reader["materia"].ToString(),
                                    Nota1 = decimal.Parse(reader["notaN1"].ToString()),
                                    Nota2 = decimal.Parse(reader["notaN2"].ToString()),
                                    Nota3 = decimal.Parse(reader["notaN3"].ToString()),
                                    NotaPromedio = decimal.Parse(reader["notapromeido"].ToString())
                                };
                                notas.Add(notas1);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return notas;
        }
    }


}