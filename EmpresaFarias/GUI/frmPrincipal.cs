using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassesBasicas;

namespace GUI
{
    public partial class frmPrincipal : Form
    {
        Usuario usuario = new Usuario();
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Perfil p = new Perfil();
            p.Tags.Add(1);
            usuario.Perfis.Add(p);
            usuario.HabilitarComponentes(this);
            usuario.HabilitarComponentes(menuStrip1);

            usuario.HabilitarComponentes(tabControl1);
            usuario.HabilitarComponentes(panel1);
        }

        private void cadastroDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadUsuario frm = new frmCadUsuario();
            frm.ShowDialog();
        }
    }
}
