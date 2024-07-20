using SoftCotton.BusinessLogic;
using SoftCotton.Model.Enterprise;
using SoftCotton.Repository;
using SoftCotton.Util;
using SoftCotton.Views.Requerimiento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftCotton.Views.Configuraciones
{
    public partial class ConfiguracionesView : Form
    {
        EmpresaBL _empresaBL = new EmpresaBL();
        Get1_Empresas listaEmpresas = new Get1_Empresas();
        public ConfiguracionesView()
        {
            InitializeComponent();
        }

        private void ConfiguracionesView_Load(object sender, EventArgs e)
        {
            listaEmpresas = _empresaBL.Get1_EmpresasConf();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = listaEmpresas;

            lblid.Text = listaEmpresas.idEmpresa.ToString();
            txtRUC.Text = listaEmpresas.ruc;
            txtRazonSocial.Text = listaEmpresas.rs;
            txtDireccion.Text = listaEmpresas.direccion;
            chkActivarKardex.Checked = listaEmpresas.Activar_Transa_Kardex;
            chkValidarStockExpor.Checked = listaEmpresas.Validar_stock_exportacion;

        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            Get1_Empresas _item;
            _item = new Get1_Empresas();
            _item.idEmpresa = Convert.ToInt32(lblid.Text);
            _item.ruc = txtRUC.Text;
            _item.rs = txtRazonSocial.Text;
            _item.direccion = txtDireccion.Text;
            _item.Activar_Transa_Kardex = chkActivarKardex.Checked;
            _item.Validar_stock_exportacion = chkValidarStockExpor.Checked;

            string resultado = _empresaBL.uspSetempresa(_item); if (resultado != "")
            {               
                ResponseMessage.Message("Actualizado Correctamente" , "INFORMATION");
            }
            else
            {
                ResponseMessage.Message("Error al Actualizar", "ERROR");
            }

        }
    }
}
