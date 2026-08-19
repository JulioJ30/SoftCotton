using SoftCotton.BusinessLogic;
using SoftCotton.Model.ServiceOrder;
using SoftCotton.Util;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SoftCotton.Views.ServiceOrder
{
    /// <summary>
    /// Ventana modal para adjuntar, ver y eliminar cotizaciones (u otros archivos) de una
    /// Orden de Servicio. Trabaja sobre la lista en memoria que le pasa RegistroOSView: los
    /// archivos nuevos quedan "Pendiente" (idAdjunto = 0) hasta que se guarda la OS; los que
    /// ya estan en BD (idAdjunto > 0) se pueden ver o eliminar de inmediato.
    ///
    /// No tiene Designer.cs / .resx: los controles se arman en BuildUI() para mantener el
    /// cambio autocontenido en un solo archivo.
    /// </summary>
    public class AdjuntosOSView : Form
    {
        private const long TAMANIO_MAXIMO_BYTES = 15 * 1024 * 1024; // 15 MB por archivo

        private readonly BindingList<AdjuntoOSItem> _adjuntos;
        private readonly OrdenServicioBL _ordenServicioBL;

        private DataGridView dgvAdjuntos;
        private Button btnAdjuntar;
        private Button btnAbrir;
        private Button btnEliminar;
        private Button btnCerrar;

        public AdjuntosOSView(System.Collections.Generic.List<AdjuntoOSItem> adjuntos)
        {
            _ordenServicioBL = new OrdenServicioBL();
            _adjuntos = new BindingList<AdjuntoOSItem>(adjuntos);

            BuildUI();

            dgvAdjuntos.DataSource = _adjuntos;
        }

        private void BuildUI()
        {
            Text = "Cotizaciones Adjuntas";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(760, 420);

            dgvAdjuntos = new DataGridView
            {
                Location = new Point(12, 12),
                Size = new Size(736, 330),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoGenerateColumns = false,
                RowHeadersVisible = false
            };

            dgvAdjuntos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNombre",
                HeaderText = "Archivo",
                DataPropertyName = "nombreArchivo",
                Width = 260
            });
            dgvAdjuntos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colExtension",
                HeaderText = "Tipo",
                DataPropertyName = "extension",
                Width = 60
            });
            dgvAdjuntos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTamanio",
                HeaderText = "KB",
                DataPropertyName = "tamanioKB",
                Width = 70
            });
            dgvAdjuntos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colUsuario",
                HeaderText = "Usuario",
                DataPropertyName = "usuarioReg",
                Width = 110
            });
            dgvAdjuntos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFecha",
                HeaderText = "Fecha",
                DataPropertyName = "fechaReg",
                Width = 130
            });
            dgvAdjuntos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEstado",
                HeaderText = "Estado",
                Width = 90
            });

            dgvAdjuntos.CellFormatting += DgvAdjuntos_CellFormatting;

            btnAdjuntar = new Button
            {
                Text = "Adjuntar",
                Image = global::SoftCotton.Properties.Resources.icon_imagen,
                ImageAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(4, 0, 0, 0),
                Location = new Point(12, 352),
                Size = new Size(130, 30),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            };
            btnAdjuntar.Click += BtnAdjuntar_Click;

            btnAbrir = new Button
            {
                Text = "Ver / Abrir",
                Image = global::SoftCotton.Properties.Resources.icon_buscar,
                ImageAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(4, 0, 0, 0),
                Location = new Point(148, 352),
                Size = new Size(130, 30),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            };
            btnAbrir.Click += BtnAbrir_Click;

            btnEliminar = new Button
            {
                Text = "Eliminar",
                Image = global::SoftCotton.Properties.Resources.icon_eliminar,
                ImageAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(4, 0, 0, 0),
                Location = new Point(284, 352),
                Size = new Size(130, 30),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            };
            btnEliminar.Click += BtnEliminar_Click;

            btnCerrar = new Button
            {
                Text = "Cerrar",
                Location = new Point(648, 352),
                Size = new Size(100, 30),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right
            };
            btnCerrar.Click += (s, e) => Close();

            Controls.Add(dgvAdjuntos);
            Controls.Add(btnAdjuntar);
            Controls.Add(btnAbrir);
            Controls.Add(btnEliminar);
            Controls.Add(btnCerrar);
        }

        private void DgvAdjuntos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAdjuntos.Columns[e.ColumnIndex].Name != "colEstado")
            {
                return;
            }

            AdjuntoOSItem item = dgvAdjuntos.Rows[e.RowIndex].DataBoundItem as AdjuntoOSItem;
            if (item != null)
            {
                e.Value = item.Guardado ? "Guardado" : "Pendiente de guardar";
            }
        }

        private void BtnAdjuntar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Title = "Seleccionar cotizacion(es) a adjuntar";
                dialogo.Filter = "Documentos (*.pdf;*.jpg;*.jpeg;*.png;*.doc;*.docx;*.xls;*.xlsx)|*.pdf;*.jpg;*.jpeg;*.png;*.doc;*.docx;*.xls;*.xlsx|Todos los archivos (*.*)|*.*";
                dialogo.Multiselect = true;

                if (dialogo.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                foreach (string ruta in dialogo.FileNames)
                {
                    FileInfo info = new FileInfo(ruta);

                    if (info.Length > TAMANIO_MAXIMO_BYTES)
                    {
                        ResponseMessage.Message("El archivo \"" + info.Name + "\" supera el tamaño máximo permitido (15 MB).", "WARNING");
                        continue;
                    }

                    AdjuntoOSItem item = new AdjuntoOSItem
                    {
                        idAdjunto = 0,
                        nombreArchivo = info.Name,
                        extension = info.Extension.TrimStart('.').ToUpper(),
                        contenido = File.ReadAllBytes(ruta),
                        tamanioKB = Math.Round(info.Length / 1024m, 2),
                        usuarioReg = UserApplication.USUARIO,
                        fechaReg = DateTime.Now.ToString("yyyy-MM-dd HH:mm")
                    };

                    _adjuntos.Add(item);
                }
            }
        }

        private void BtnAbrir_Click(object sender, EventArgs e)
        {
            AdjuntoOSItem item = ObtenerSeleccionado();
            if (item == null)
            {
                return;
            }

            try
            {
                byte[] contenido = item.contenido;

                if (contenido == null && item.Guardado)
                {
                    GetOS29_AdjuntoContenido adjunto = _ordenServicioBL.Get29_AdjuntoContenido(item.idAdjunto);

                    if (adjunto == null)
                    {
                        ResponseMessage.Message("No se pudo obtener el archivo, es posible que haya sido eliminado.", "WARNING");
                        return;
                    }

                    contenido = adjunto.contenido;
                }

                if (contenido == null)
                {
                    ResponseMessage.Message("El archivo no tiene contenido para mostrar.", "WARNING");
                    return;
                }

                string carpetaTemporal = Path.Combine(Path.GetTempPath(), "SoftCotton_Adjuntos");
                Directory.CreateDirectory(carpetaTemporal);

                string rutaTemporal = Path.Combine(carpetaTemporal, item.nombreArchivo);
                File.WriteAllBytes(rutaTemporal, contenido);

                Process.Start(new ProcessStartInfo(rutaTemporal) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                ResponseMessage.Message("No se pudo abrir el archivo: " + ex.Message, "ERROR");
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            AdjuntoOSItem item = ObtenerSeleccionado();
            if (item == null)
            {
                return;
            }

            DialogResult confirmacion = ResponseMessage.MessageQuestion("¿Esta seguro en eliminar el adjunto \"" + item.nombreArchivo + "\"?");
            if (confirmacion != DialogResult.OK)
            {
                return;
            }

            if (item.Guardado)
            {
                SetOSAdjuntoParam parametro = new SetOSAdjuntoParam
                {
                    opcion = 2,
                    idAdjunto = item.idAdjunto
                };

                Response respuesta = _ordenServicioBL.SetOSAdjunto(parametro);

                if (respuesta.idResponse <= 0)
                {
                    ResponseMessage.Message(respuesta.messageResponse, respuesta.typeMessage);
                    return;
                }
            }

            _adjuntos.Remove(item);
        }

        private AdjuntoOSItem ObtenerSeleccionado()
        {
            if (dgvAdjuntos.CurrentRow == null)
            {
                ResponseMessage.Message("Seleccione un adjunto de la lista.", "INFORMATION");
                return null;
            }

            return dgvAdjuntos.CurrentRow.DataBoundItem as AdjuntoOSItem;
        }
    }
}
