using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace RemGRE
{
    public partial class ShowMissings : Form
    {
        Hashtable missings;
        Point p;
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape) || e.KeyChar==Convert.ToChar(Keys.Enter))
            {
                this.Close();
            }
        }
        public ShowMissings(Hashtable m,Point p)
        {
            missings = m;
            this.p = p;
            InitializeComponent();
        }

        private void rtfMissings_Enter(object sender, EventArgs e)
        {
            this.lbNull.Focus();
        }

        private void ShowMissings_Load(object sender, EventArgs e)
        {
            this.Location = p;
            if (missings.Count == 0) this.rtfMissings.Text = "There are no missing words.";
            else
            {
                foreach (String key in missings.Keys)
                {
                    this.rtfMissings.AppendText(key.ToString() + "\t" + missings[key] + "\n");
                }
                this.Text = "Missings (" + this.missings.Count + " in total)";
            }
        }
    }
}
