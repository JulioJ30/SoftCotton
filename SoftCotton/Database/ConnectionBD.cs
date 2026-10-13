using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using SoftCotton.Util;

namespace SoftCotton.Database
{
    public static class ConnectionBD
    {
        // public static readonly string _connectionString = "Data Source=SERVIDOR;Initial Catalog=bdsoftcotton;User ID=usoftcotton;Password=$usoftcotton.22;";
        //public static readonly string _connectionString = "Data Source=DATASERVER;Initial Catalog=bdsoftcotton;User ID=sa;Password=.com2017;";
        // public static readonly string _connectionString = "Data Source=SERVIDOR;Initial Catalog=bdsoftcotton_prueba;User ID=usoftcotton;Password=$usoftcotton.22;";
        // public static readonly string _connectionString = "Data Source=FCONDOR;Initial Catalog=bdsoftcottonv3;Integrated Security=True;";
        //public static readonly string _connectionString = "Data Source=.;Initial Catalog=bdsoftcottonv3;Integrated Security=True;";
        //public static readonly string _connectionString = "Data Source=LAPTOTSC178\\SQLEXPRESS;Initial Catalog=bdsoftcotton;Integrated Security=True;";

        //public static readonly string _connectionString = "Data Source=LAPTOTSC178\\SQLEXPRESS;Initial Catalog=bdsoftcottonv7;Integrated Security=True;";
        //public static readonly string _connectionString = "Data Source=.;Initial Catalog=bdsoftcotton;Integrated Security=True;";
        private static string CadenaConexion = string.Empty;

        public static SqlConnection GetConnection()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string ambiente = appSettings["ambiente"] ?? "P";

                if (ambiente == "P")
                {
                    CadenaConexion = ConfigurationManager.ConnectionStrings["cnxsql"].ToString() + " Password=$usoftcotton.22;";
                }
                if(ambiente == "D")
                {
                    CadenaConexion = ConfigurationManager.ConnectionStrings["cnxsql"].ToString();
                }

                if (ambiente == "NUBEP")
                {
                    CadenaConexion = ConfigurationManager.ConnectionStrings["cnxsqlproduccion"].ToString();
                }

                var sqlConnection = new SqlConnection(CadenaConexion);
                sqlConnection.StateChange += RegistrarUsuarioEnSesion;

                return sqlConnection;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Deja el usuario logueado en SESSION_CONTEXT('usuario') cada vez que se abre la conexion.
        // Los procedimientos lo leen via dbo.fnPeriodoBloqueado para permitir al ADMIN operar en
        // periodos cerrados.
        private static void RegistrarUsuarioEnSesion(object sender, StateChangeEventArgs e)
        {
            if (e.CurrentState != ConnectionState.Open)
            {
                return;
            }

            using (var sqlCommand = ((SqlConnection)sender).CreateCommand())
            {
                sqlCommand.CommandText = "sp_set_session_context";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@key", SqlDbType.NVarChar, 128).Value = "usuario";
                sqlCommand.Parameters.Add("@value", SqlDbType.NVarChar, 50).Value = (object)UserApplication.USUARIO ?? DBNull.Value;

                sqlCommand.ExecuteNonQuery();
            }
        }
        



    }
}
