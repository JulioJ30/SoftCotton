using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftCotton.BusinessLogic;
using SoftCotton.Model.Maintenance;
using SoftCotton.Util;

namespace SoftCotton.Views.Maintenance
{
    public partial class RegistroEstilosView : Form
    {
        MantenimientoBL _mantenimientoBL;
        SetEstilosParam _estilosParam;
        int id = 0;
        public RegistroEstilosView()
        {
            InitializeComponent();
            _mantenimientoBL = new MantenimientoBL();
            
        }

        private void RegistroEstilosView_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void Nuevo()
        {
            Limpiar();
            Listar();
            txtCodigoEstilo.Focus();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        // ### Funciones ###

        public void Guardar()
        {
            if (ValidarDatos())
            {
                _estilosParam = new SetEstilosParam();

                _estilosParam.opcion = id != 0 ? 2 : 1;
                _estilosParam.idEstilo = id;
                _estilosParam.codigoEstilo = txtCodigoEstilo.Text.Trim();
                _estilosParam.estilo = txtEstilo.Text.Trim();
                _estilosParam.idUsuarioCrea = UserApplication.ID_USUARIO; // UserApplication.USUARIO;


                Procesar(_estilosParam);
            }
        }

        public void Procesar(SetEstilosParam parametro)
        {
            Response responseGeneral = _mantenimientoBL.setEstilosMantenimiento(parametro);

            if (responseGeneral.idResponse > 0)
            {
                Limpiar();
                Listar();
            }
            else
            {
                ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
            }
        }

        public void Listar()
        {
            List<GetMant53_Estilos> listaEstilos = _mantenimientoBL.GetEstilos().ToList();

            dgvListado.Rows.Clear();

            foreach (var item in listaEstilos)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["codigoEstilo"].Value = item.codigoEstilo;
                dgvListado.Rows[index].Cells["estilo"].Value = item.estilo;
                dgvListado.Rows[index].Cells["estado"].Value = item.estado;
                dgvListado.Rows[index].Cells["idEstilo"].Value = item.idEstilo;

                if (item.estado)
                {
                    //dgvListado.Rows[index].Cells["cbxActivo"].Value = true;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.BackColor = Color.MediumSeaGreen;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.SelectionBackColor = Color.MediumSeaGreen;
                    //dgvListado.Rows[index].Cells["cbtnEliminar"].Style.BackColor = Color.LightCoral;
                    //dgvListado.Rows[index].Cells["cbtnEliminar"].Style.SelectionBackColor = Color.LightCoral;
                }
                else
                {
                    //dgvListado.Rows[index].Cells["cbxActivo"].Value = false;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.BackColor = Color.Gray;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.SelectionBackColor = Color.Gray;
                    //dgvListado.Rows[index].Cells["cbtnEliminar"].Style.BackColor = Color.Gray;
                    //dgvListado.Rows[index].Cells["cbtnEliminar"].Style.SelectionBackColor = Color.Gray;
                }
            }

            lblCantRegistros.Text = "Cantidad de Registros: " + dgvListado.Rows.Count.ToString();
            dgvListado.ClearSelection();
        }

        private bool ValidarDatos()
        {
            bool validacion = false;

            if (string.IsNullOrEmpty(txtCodigoEstilo.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el código de estilo", "INFORMATION");
                txtCodigoEstilo.Focus();
            }
            else if (string.IsNullOrEmpty(txtEstilo.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese la descripción del Estilo", "INFORMATION");
                txtEstilo.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Limpiar()
        {
            txtCodigoEstilo.Clear();
            txtEstilo.Clear();
            //txtColor.Text = "";
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEditar"))
            {
                if (Convert.ToBoolean(dgvListado.Rows[e.RowIndex].Cells["estado"].Value))
                {
                    id =  Convert.ToInt32( dgvListado.Rows[e.RowIndex].Cells["idEstilo"].Value.ToString().Trim());
                    txtCodigoEstilo.Text = dgvListado.Rows[e.RowIndex].Cells["codigoEstilo"].Value.ToString().Trim();
                    txtEstilo.Text = dgvListado.Rows[e.RowIndex].Cells["estilo"].Value.ToString().Trim();

                }
                else
                {
                    Limpiar();
                }
            }
            //else if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEliminar"))
            //{
            //    if (Convert.ToBoolean(dgvListado.Rows[e.RowIndex].Cells["cbxActivo"].Value))
            //    {
            //        string codColor = dgvListado.Rows[e.RowIndex].Cells["ctxtCodColor"].Value.ToString();
            //        DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

            //        if (pregunta.Equals(DialogResult.OK))
            //        {
            //            _ColorParam = new SetColorParam();
            //            _ColorParam.opcion = 4; // ELIMINAR 
            //            _ColorParam.codColor = codColor;
            //            _ColorParam.usuarioReg = UserApplication.USUARIO;

            //            Procesar(_ColorParam);
            //        }
            //    }
            //    else
            //    {
            //        Limpiar();
            //    }
            //}
        }

        private void dgvListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvListado.Columns[e.ColumnIndex].Name.Equals("cbxActivo"))
            {
                DataGridViewRow row = dgvListado.Rows[e.RowIndex];
                bool valorCheck = !Convert.ToBoolean(row.Cells["cbxActivo"].Value);
                string pregunta = "";

                if (valorCheck)
                {
                    pregunta = "¿Desea activar estilo?";
                }
                else
                {
                    pregunta = "¿Desea deshabilitar el estilo?";
                }

                DialogResult resultadoPregunta = ResponseMessage.MessageQuestion(pregunta);

                if (resultadoPregunta.Equals(DialogResult.OK))
                {
                    row.Cells["estado"].Value = valorCheck;

                    _estilosParam = new SetEstilosParam();

                    _estilosParam.opcion = 3; // INHABILITAR
                    _estilosParam.idEstilo =  Convert.ToInt32(row.Cells["idEstilo"].Value.ToString());
                    //_ColorParam.usuarioReg = UserApplication.USUARIO;
                    _estilosParam.estado = valorCheck;

                    Procesar(_estilosParam);
                }
            }
        }
    }
}
