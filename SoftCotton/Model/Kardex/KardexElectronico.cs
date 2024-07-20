using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCotton.Model.Kardex
{
    public class KardexElectronico
    {

        public string MATERIAL { get; set; }
        public string TPO_MATERIAL { get; set; }
        public string N_CUBSO { get; set; }
        public string N_LOGISTICA { get; set; }
        public string N_CONTAB { get; set; }
        public string PERIODO { get; set; }
        public string CUO { get; set; }
        public string NUMERO_CORRELATIVO { get; set; }
        public string COD_ESTABLECIMIENTO { get; set; }
        public string ESTABLEC { get; set; }
        public string COD_CATALOGO { get; set; }
        public string TIPO_EXISTENCIA { get; set; }
        public string CODIGO_PROPIO_EXISTENCIA { get; set; }
        public string CATALOGO_UNICO_BIENES { get; set; }
        public string CODIGO_EXISTENCIA_UNSPSC { get; set; }
        public DateTime FECHA { get; set; }
        public string TIPO_DOC { get; set; }
        public string N_SERIE { get; set; }
        public string N_DOCUMENTO { get; set; }
        public string TPO_OPERA { get; set; }
        public string DESC_MATERIAL { get; set; }
        public string UNID_MED { get; set; }
        public string CODIGO_METODO_VAL { get; set; }
        public string METODO_VAL { get; set; }
       
        public double CANT_ENTRADA { get; set; }
        public double Costo_Unit_Entrada { get; set; }
        public double Costo_Total_Entrada { get; set; }

        public double CANT_SALIDA { get; set; }
        public double Costo_Unit_Salida { get; set; }
        public double Costo_Total_Salida { get; set; }

        public double Cantidad_Final { get; set; }
        public double Costo_Unit_Final { get; set; }
        public double Costo_Total_Final { get; set; }

        public int Est_Op { get; set; }


    }
}
