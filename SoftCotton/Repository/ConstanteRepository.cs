using SoftCotton.Database;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SoftCotton.Repository
{
    public class ConstanteRepository
    {

        public List<Constantes> Get1_Constantes()
        {
            List<Constantes> monedas = new List<Constantes>();
            Constantes moneda;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetConstantes";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            moneda = new Constantes();
                            moneda.nombre = reader["nombre"].ToString();
                            moneda.descripcion = reader["descripcion"].ToString();
                            moneda.valor = reader["valor"].ToString();
                            monedas.Add(moneda);
                        }
                    }
                }
            }
            return monedas;
        }
    }
}
