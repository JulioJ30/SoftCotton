using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftCotton.Views.Almacen
{
    /// <summary>
    /// Formulario base para pantallas que consultan la base de datos de forma asíncrona.
    ///
    /// - Las operaciones corren con async/await: la interfaz nunca se congela y el resultado
    ///   vuelve al hilo de la UI automáticamente (no hay Invoke manual ni hilos sueltos).
    /// - Mientras una operación bloqueante está en curso se muestra un indicador de carga y
    ///   se deshabilita el contenido, para evitar dobles clics / dobles grabaciones.
    /// - Al cerrar el formulario se cancelan las consultas pendientes (CancellationToken).
    /// - Los errores se muestran con ResponseMessage; las cancelaciones se ignoran.
    /// </summary>
    public class FormularioAsync : Form
    {
        private readonly CancellationTokenSource _cierre = new CancellationTokenSource();
        private readonly Panel _panelCarga;
        private readonly Label _lblCarga;
        private readonly List<Control> _deshabilitados = new List<Control>();
        private int _operacionesBloqueantes;
        private bool _grabando;

        public FormularioAsync()
        {
            Font = EstiloVisual.Fuente;
            BackColor = EstiloVisual.Fondo;

            _lblCarga = new Label
            {
                Dock = DockStyle.Top,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = EstiloVisual.FuenteSeccion,
                ForeColor = EstiloVisual.Texto,
                Text = "Cargando..."
            };

            var barra = new ProgressBar
            {
                Dock = DockStyle.Top,
                Height = 6,
                Style = ProgressBarStyle.Marquee,
                MarqueeAnimationSpeed = 25
            };

            _panelCarga = new Panel
            {
                Size = new Size(300, 66),
                BackColor = EstiloVisual.Superficie,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(16, 10, 16, 10),
                Visible = false
            };
            _panelCarga.Controls.Add(barra);
            _panelCarga.Controls.Add(_lblCarga);
            Controls.Add(_panelCarga);

            Resize += (s, e) => CentrarPanelCarga();
        }

        /// <summary>Token que se cancela al cerrar el formulario.</summary>
        protected CancellationToken TokenCierre
        {
            get { return _cierre.Token; }
        }

        protected bool Ocupado
        {
            get { return _operacionesBloqueantes > 0; }
        }

        /// <summary>
        /// Ejecuta una operación asíncrona mostrando el indicador de carga y bloqueando la
        /// pantalla. Devuelve false si falló o se canceló.
        /// </summary>
        protected Task<bool> EjecutarAsync(Func<CancellationToken, Task> accion, string mensaje = "Cargando...")
        {
            return EjecutarAsync(accion, mensaje, true, CancellationToken.None);
        }

        /// <summary>
        /// Igual que EjecutarAsync, pero marca la operación como grabación: mientras dure no
        /// se permite cerrar el formulario ni se cancela al intentar cerrarlo.
        /// </summary>
        protected async Task<bool> EjecutarGrabacionAsync(Func<CancellationToken, Task> accion, string mensaje = "Grabando...")
        {
            _grabando = true;
            try
            {
                return await EjecutarAsync(accion, mensaje, true, CancellationToken.None);
            }
            finally
            {
                _grabando = false;
            }
        }

        /// <param name="bloquear">false para operaciones en segundo plano que no deben bloquear
        /// la pantalla (por ejemplo, la búsqueda mientras se escribe).</param>
        /// <param name="tokenAdicional">token propio de la operación (por ejemplo, para
        /// cancelar una búsqueda anterior cuando el usuario sigue escribiendo).</param>
        protected async Task<bool> EjecutarAsync(Func<CancellationToken, Task> accion, string mensaje, bool bloquear, CancellationToken tokenAdicional)
        {
            using (var enlace = CancellationTokenSource.CreateLinkedTokenSource(_cierre.Token, tokenAdicional))
            {
                if (bloquear)
                {
                    MostrarCarga(mensaje);
                }

                try
                {
                    await accion(enlace.Token);
                    return true;
                }
                catch (Exception) when (enlace.IsCancellationRequested)
                {
                    // cierre del formulario o búsqueda reemplazada por una más nueva
                    return false;
                }
                catch (Exception ex)
                {
                    if (!IsDisposed)
                    {
                        ResponseMessage.Message("No se pudo completar la operación.\n\n" + ex.Message, "ERROR");
                    }
                    return false;
                }
                finally
                {
                    if (bloquear && !IsDisposed)
                    {
                        OcultarCarga();
                    }
                }
            }
        }

        private void MostrarCarga(string mensaje)
        {
            _lblCarga.Text = mensaje;
            _operacionesBloqueantes++;
            if (_operacionesBloqueantes > 1)
            {
                return;
            }

            foreach (Control control in Controls)
            {
                if (control != _panelCarga && control.Enabled)
                {
                    control.Enabled = false;
                    _deshabilitados.Add(control);
                }
            }

            UseWaitCursor = true;
            CentrarPanelCarga();
            _panelCarga.Visible = true;
            _panelCarga.BringToFront();
        }

        private void OcultarCarga()
        {
            _operacionesBloqueantes = Math.Max(0, _operacionesBloqueantes - 1);
            if (_operacionesBloqueantes > 0)
            {
                return;
            }

            _panelCarga.Visible = false;
            foreach (var control in _deshabilitados)
            {
                control.Enabled = true;
            }
            _deshabilitados.Clear();
            UseWaitCursor = false;
        }

        private void CentrarPanelCarga()
        {
            _panelCarga.Location = new Point(
                Math.Max(0, (ClientSize.Width - _panelCarga.Width) / 2),
                Math.Max(0, (ClientSize.Height - _panelCarga.Height) / 2));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Si se está grabando, no se permite cerrar a medias. Una consulta, en cambio, se
            // cancela al cerrar.
            if (_grabando && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                return;
            }

            _cierre.Cancel();
            base.OnFormClosing(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cierre.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
