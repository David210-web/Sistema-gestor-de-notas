using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;

namespace GestionDeNotas.Models.Database
{
    public class MatriculaInscripcion
    {
        public static void Matricularse(string carnet,string codigo)
        {
            try
            {
                using (var connection = Conexion.GetSqlConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("INSERT INTO Matricula (alumno,curso) VALUES (@alumno,@curso)", connection))
                    {
                        cmd.Parameters.AddWithValue("@alumno", carnet);
                        cmd.Parameters.AddWithValue("@curso", codigo);

                        cmd.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}