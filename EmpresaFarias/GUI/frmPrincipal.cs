﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassesBasicas;
using Negocio;
using GUI.Relatorios;

namespace GUI
{
    public partial class frmPrincipal : Form
    {
        Fachada fachada = Fachada.Instance;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private bool VerificarUsuario()
        {
            if (fachada.Usuario.Id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            fachada.Usuario.HabilitarComponentes(this);
            fachada.Usuario.HabilitarComponentes(menuPrincipal);

            MudarMensagem();
        }

        private void MudarMensagem()
        {
            if (fachada.Usuario.Id > 0)
            {
                lbInformacaoGeral.Text = "Usuario Logado - " + fachada.Usuario;
            }
            else
                lbInformacaoGeral.Text = "Nenhum Usuário Logado";
        }

        private void cadastroDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadUsuario frm = new frmCadUsuario();
            frm.ShowDialog();
        }

        private void logarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!VerificarUsuario())
            {
                frmLogin frm = new frmLogin();
                frm.ShowDialog();
                if (VerificarUsuario())
                {
                    logarToolStripMenuItem.Text = "Deslogar";
                }
            }
            else
            {
                fachada.Usuario = new Usuario();
                logarToolStripMenuItem.Text = "Logar";

            }
            fachada.Usuario.HabilitarComponentes(this);
            fachada.Usuario.HabilitarComponentes(menuPrincipal);
            MudarMensagem();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cadastroDeTitularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTitular frmT = new frmTitular();
            frmT.ShowDialog();
        }

        private void contratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInputContrato f = new frmInputContrato();
            f.Show();            
        }


    }
}
