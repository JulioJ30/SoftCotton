using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

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
                else
                {
                    CadenaConexion = ConfigurationManager.ConnectionStrings["cnxsql"].ToString();
                }
                 
                return new SqlConnection(CadenaConexion);
            }
            catch (Exception)
            {
                throw;
            }
        }
        



    }
}
