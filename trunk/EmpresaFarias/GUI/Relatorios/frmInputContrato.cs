using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI.Relatorios
{
    public partial class frmInputContrato : Form
    {
        public frmInputContrato()
        {
            InitializeComponent();
        }

        private void btnGerarContrato_Click(object sender, EventArgs e)
        {
            frmRelatorioTitular f = new frmRelatorioTitular(int.Parse(txtContrato.Text));
            f.Show();            
        }
    }
}
