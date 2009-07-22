using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUI.Relatorios;

namespace GUI
{
    

    public partial class frmRelatorioTitular : Form
    {
        private int contrato;
        
        public frmRelatorioTitular()
        {
            InitializeComponent();
        }

        public frmRelatorioTitular(int codigo)
        {
            contrato = codigo;
            InitializeComponent();            
        }

        private void Carregar(int codigo)
        {
            dsRelatorioTitular dts = new dsRelatorioTitular();
            rptRelatorioTitular rpt = new rptRelatorioTitular();

            rpt.SetDataSource(dts);

            crwRelatorioTitular.ReportSource = rpt;

            rpt.RecordSelectionFormula = "{Contrato.Id} = " + codigo + "";             

            rpt.Refresh();
        }

        private void crwRelatorioTitular_Load(object sender, EventArgs e)
        {
            Carregar(contrato);
        }
    }
}
