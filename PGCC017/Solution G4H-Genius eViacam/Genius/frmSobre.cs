using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Genius
{
    public partial class frmSobre : Form
    {
        public frmSobre()
        {
            InitializeComponent();
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabelMarcos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Especifique que o link foi visitado.
            this.linkLabelMarcos.LinkVisited = true;
            // Navegue para uma página na internet
            System.Diagnostics.Process.Start("https://linktr.ee/marcosmoraisjr");
        }

        private void frmSobre_Load(object sender, EventArgs e)
        {

        }
    }
}
