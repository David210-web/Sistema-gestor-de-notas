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
    }
}