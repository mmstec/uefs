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
    public partial class frmSplashScreen : Form
    {
        int x, i;
        public frmSplashScreen()
        {
            InitializeComponent();
         }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;
            x = (100 * panel2.Width) / this.Width;
            label2.Text = x.ToString() + "%";

            #region efeite
            if (x <= 12.5)
            {
                panel11.BackgroundImage = Properties.Resources.splash1;
            }
            else if (x <= 25)
            {
                panel11.BackgroundImage = Properties.Resources.splash2;
            }
            else if (x <= 37.5)
            {
                panel11.BackgroundImage = Properties.Resources.splash3;
            }
            else if (x <= 50)
            {
                panel11.BackgroundImage = Properties.Resources.splash4;
            }
            else
            {
                if (x <= 62.5)
                {
                    panel11.BackgroundImage = Properties.Resources.splash1;
                }
                else if (x <= 75)
                {
                    panel11.BackgroundImage = Properties.Resources.splash2;
                }
                else if (x <= 87.5)
                {
                    panel11.BackgroundImage = Properties.Resources.splash3;
                }
                else if (x <= 100)
                {
                    panel11.BackgroundImage = Properties.Resources.splash4;
                }
            }

            if (x <= 3) { 
                label3.Text = "Preparando..."; 
            }
            else if (x <= 10){
                label3.Text = "Preparando...";
            }
            else if (x <= 33) { 
                label3.Text = "Carregando textos..."; 
            }
            else if (x <= 66) { 
                label3.Text = "Carregando objetos..."; 
            }
            else if (x <= 100) { 
                label3.Text = "Carregando algoritmos..."; 
            }
            else { 
                label3.Text = string.Empty; 
            }
            #endregion

            if (panel2.Width >= this.Width)
            {
                timer1.Stop();
                frmGenius frm = new frmGenius();
                frm.Show();
                this.Hide();
            }
        
        }
    }
}
