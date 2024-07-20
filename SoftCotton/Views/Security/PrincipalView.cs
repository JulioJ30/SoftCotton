using SoftCotton.BusinessLogic;
using SoftCotton.Model.Security;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SoftCotton.Views.Security
{
    public partial class PrincipalView : Form
    {
        SeguridadBL _seguridadBL;

        public PrincipalView(string idUsuario,
                            string usuario,
                            string nomeApellidos)
        {
            InitializeComponent();

            tssIdUsuario.Text = idUsuario;
            tssUsuario.Text = usuario;
            tssNomApe.Text = " - " + nomeApellidos;

            _seguridadBL = new SeguridadBL();
        }



        private void PrincipalView_Load(object sender, EventArgs e)
        {
            MenuStrip menuStrip = new MenuStrip();
            List<GetAcceso2_Mod> listaAccesos = _seguridadBL.Get_Accesos(Convert.ToInt32(tssIdUsuario.Text));


            foreach (var item in listaAccesos)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem(item.modulo);

                if (item.subModulos != null)
                {
                    foreach (var itemHijo in item.subModulos)
                    {
                        ToolStripMenuItem itemm = new ToolStripMenuItem(itemHijo.submodulo);

                        itemm.Name = "tsi" + itemHijo.idSubModulo.ToString();
                        itemm.Tag = itemHijo.rutaForm;
                        itemm.Text = itemHijo.submodulo;
                        itemm.Click += new EventHandler(MenuItemClickHandler);

                        menuItem.DropDownItems.Add(itemm);
                    }
                }

                menuStrip.Items.Add(menuItem);
            }

            this.MainMenuStrip = menuStrip;
            Controls.Add(menuStrip);

        }


        private void MenuItemClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            string sFormName = "SoftCotton." + ((ToolStripMenuItem)sender).Tag.ToString();
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            Form frm = (Form)asm.CreateInstance(sFormName);
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void PrincipalView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
