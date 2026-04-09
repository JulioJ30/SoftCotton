using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;
using SoftCotton.BusinessLogic;
using SoftCotton.Model.Maintenance;
using SoftCotton.Util;

namespace SoftCotton.Views.Maintenance
{
    public partial class RegistroDeTemporadasView : Form
    {
        int? _IdTemporada = null;
        MantenimientoBL _mantenimientoBL;

        public RegistroDeTemporadasView()
        {
            InitializeComponent();
            _mantenimientoBL = new MantenimientoBL();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TemporadasEntidad parametro = new TemporadasEntidad();

            parametro.Temporada = txtTemporada.Text.Trim();
            parametro.TemporadaDescripcion = txtDescripcion.Text.Trim();
            parametro.Anio = int.Parse(txtAnio.Text.Trim());



            RegistrarTemporada(parametro);
        }


        private void RegistrarTemporada(TemporadasEntidad parametroEntrada)
        {
            TemporadasEntidad parametro = new TemporadasEntidad();

            parametro.IdTemporada = _IdTemporada ?? 0;
            parametro.Anio = parametroEntrada.Anio;
            parametro.Temporada = parametroEntrada.Temporada;
            parametro.TemporadaDescripcion = parametroEntrada.TemporadaDescripcion;

            string mensaje = string.Empty;
            var response = _mantenimientoBL.SetTemporadas(parametro,out mensaje);

            if (response)
            {
                Limpiar();
                ListarData();
            }

        }

        private void Limpiar()
        {
            txtAnio.Clear();
            txtDescripcion.Clear();
            txtTemporada.Clear();
            _IdTemporada = null;

            btnCancelar.Visible = false;
            btnNuevo.Visible = true;

        }

        private void ListarData()
        {
            List<TemporadasEntidad> listData = _mantenimientoBL.GetTemporadas(null).ToList();

            dgvData.Rows.Clear();

            foreach (var item in listData)
            {
                int index = dgvData.Rows.Add();

                dgvData.Rows[index].Cells["IdTemporada"].Value = item.IdTemporada;
                dgvData.Rows[index].Cells["Anio"].Value = item.Anio;
                dgvData.Rows[index].Cells["Temporada"].Value = item.Temporada;
                dgvData.Rows[index].Cells["TemporadaDescripcion"].Value = item.TemporadaDescripcion;
                dgvData.Rows[index].Cells["EstadoListado"].Value = item.FlgActivo ? "Activo": "Inactivo";


                if (item.FlgActivo)
                {
                    dgvData.Rows[index].Cells["Accion"].Style.BackColor = Color.MediumSeaGreen;
                    dgvData.Rows[index].Cells["Accion"].Style.SelectionBackColor = Color.MediumSeaGreen;
                    dgvData.Rows[index].Cells["Estado"].Style.BackColor = Color.LightCoral;
                    dgvData.Rows[index].Cells["Estado"].Style.SelectionBackColor = Color.LightCoral;
                }
                else
                {
                    dgvData.Rows[index].Cells["Accion"].Style.BackColor = Color.Gray;
                    dgvData.Rows[index].Cells["Accion"].Style.SelectionBackColor = Color.Gray;
                    dgvData.Rows[index].Cells["Estado"].Style.BackColor = Color.Gray;
                    dgvData.Rows[index].Cells["Estado"].Style.SelectionBackColor = Color.Gray;
                }
            }

            //lblCantRegistros.Text = "Cantidad de Registros: " + dgvListado.Rows.Count.ToString();
            dgvData.ClearSelection();
        }

        private void RegistroDeTemporadasView_Load(object sender, EventArgs e)
        {
            ListarData();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name.Equals("Accion"))
            {
                
                _IdTemporada = int.Parse(dgvData.Rows[e.RowIndex].Cells["IdTemporada"].Value.ToString().Trim());
                txtTemporada.Text = dgvData.Rows[e.RowIndex].Cells["Temporada"].Value.ToString().Trim();
                txtDescripcion.Text = dgvData.Rows[e.RowIndex].Cells["TemporadaDescripcion"].Value.ToString().Trim();
                txtAnio.Text = dgvData.Rows[e.RowIndex].Cells["Anio"].Value.ToString().Trim();
                gbRegistro.Enabled = true;
                btnNuevo.Visible = false;
                btnCancelar.Visible = true;
            }
            else if (dgvData.Columns[e.ColumnIndex].Name.Equals("Estado"))
            {
                
                _IdTemporada = int.Parse(dgvData.Rows[e.RowIndex].Cells["IdTemporada"].Value.ToString().Trim());

                string mensaje = string.Empty;
                var response = _mantenimientoBL.SetTemporadasCambioEstado(_IdTemporada ?? 0, out mensaje);

                ListarData();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            gbRegistro.Enabled = true;
            Limpiar();
            btnCancelar.Visible = true;
            btnNuevo.Visible = false;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            gbRegistro.Enabled = false;

        }
    }
}
