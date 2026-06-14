using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftCotton.Views.Maintenance
{
    public partial class FormVisorPdf : Form
    {
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;

        public FormVisorPdf(string url)
        {
            InitializeComponent();
            InitAsync(url);
        }

        private async void InitAsync(string url)
        {
            this.Text = "Visor PDF - Guía de Remisión";
            this.WindowState = FormWindowState.Maximized;

            webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            webView.Dock = DockStyle.Fill;
            this.Controls.Add(webView);

            await webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2.Navigate(url);
        }
    }
}
