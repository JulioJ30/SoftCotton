using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using SoftCotton.Model.Maintenance;
//using SoftCotton.Views.Employee;
using SoftCotton.BusinessLogic;
using System.Windows.Forms;
using SoftCotton.Model.Employee;


namespace SoftCotton.Views.Maintenance
{
    public partial class BuscarPeronaView : Form
    {

        MantenimientoBL _mantenimientoBL;
        EmpleadoBL _empleadoBL;
        public string numerodocumento = "";
        public string tipodocumento = "";
        public string nombres = "";
        public string apellidos = "";





        public BuscarPeronaView()
        {
            InitializeComponent();
            _empleadoBL = new EmpleadoBL();
            _mantenimientoBL = new MantenimientoBL();

        }

        private void BuscarPeronaView_Load(object sender, EventArgs e)
        {
            Listar();
        }


        public void Listar()
        {
            List<GetEmp1_Personas> listaPersona = _empleadoBL.Get1_Personas();

            dgvListado.Rows.Clear();

            foreach (var item in listaPersona)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["ctxtNumDoc"].Value = item.numDoc;
                dgvListado.Rows[index].Cells["ctxtCodTipoDoc"].Value = item.codTipoDoc;
                dgvListado.Rows[index].Cells["ctxtTipoDocCorta"].Value = item.tipoDocCorta;
                dgvListado.Rows[index].Cells["ctxtNombres"].Value = item.nombres;
                dgvListado.Rows[index].Cells["ctxtApellidoPaterno"].Value = item.apellidoPaterno;
                dgvListado.Rows[index].Cells["ctxtApellidoMaterno"].Value = item.apellidoMaterno;
                //dgvListado.Rows[index].Cells["ctxtCelular"].Value = item.celular;

                //dgvListado.Rows[index].Cells["ctxtFechaReg"].Value = item.fechaReg;
                //dgvListado.Rows[index].Cells["ctxtUsuarioReg"].Value = item.usuarioReg;

            }

            //lblCantRegistros.Text = "Cantidad de Registros: " + dgvListado.Rows.Count.ToString();
            dgvListado.ClearSelection();
        }

        private void dgvListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tipodocumento = dgvListado.Rows[e.RowIndex].Cells["ctxtCodTipoDoc"].Value.ToString();
            numerodocumento = dgvListado.Rows[e.RowIndex].Cells["ctxtNumDoc"].Value.ToString();
            apellidos = dgvListado.Rows[e.RowIndex].Cells["ctxtApellidoPaterno"].Value.ToString() + " " + dgvListado.Rows[e.RowIndex].Cells["ctxtApellidoMaterno"].Value.ToString();
            nombres = dgvListado.Rows[e.RowIndex].Cells["ctxtNombres"].Value.ToString();

            this.Close();
        }

        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (dgvListado.CurrentRow != null)
                {
                    DataGridViewRow dgr = dgvListado.CurrentRow;

                    //codProvCliente = dgr.Cells["ctxtCodigo"].Value.ToString().Trim();
                    //provCliente = dgr.Cells["ctxtRazonSocial"].Value.ToString().Trim();
                    //direccion = dgr.Cells["ctxtDireccion"].Value.ToString().Trim();
                    tipodocumento = dgr.Cells["ctxtCodTipoDoc"].Value.ToString();
                    numerodocumento = dgr.Cells["ctxtNumDoc"].Value.ToString();
                    apellidos = dgr.Cells["ctxtApellidoPaterno"].Value.ToString() + " " + dgr.Cells["ctxtApellidoMaterno"].Value.ToString();
                    nombres = dgr.Cells["ctxtNombres"].Value.ToString();

                    this.Close();
                }

            }
        }
    }
}
