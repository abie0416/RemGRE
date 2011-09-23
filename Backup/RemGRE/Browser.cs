using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RemGRE
{
    public partial class Browser : Form
    {
        public Browser()
        {
            InitializeComponent();
        }
        public void Navigate(String url)
        {
            this.webBrowser.Navigate(url);
        }

        private void Browser_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            this.Show();
            this.Focus();
        }

        private void webBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Hide();
        }
    }
}
