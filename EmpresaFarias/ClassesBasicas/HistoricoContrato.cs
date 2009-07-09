using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesBasicas
{
    /// <summary>
    /// Classe que representa os Historicos de Mudanças de um Contrato.
    /// </summary>
    public class HistoricoContrato 
    {
        private Contrato contrato;
        /// <summary>
        /// Propriedade relacionada ao Contrato monitorado pelo Historico de Mudanças.
        /// </summary>
        public Contrato Contrato
        {
            get { return contrato; }
            set { contrato = value; }
        }

        private Contrato contratoHistorico;
        /// <summary>
        /// Propriedade relacionada ao ContratoHistorico.
        /// </summary>
        public Contrato ContratoHistorico
        {
            get { return contratoHistorico; }
            set { contratoHistorico = value; }
        }
        
        

         private Usuario usuario;
        /// <summary>
         /// Propriedade relacionada ao Usuario que efetuou a mudança do Historico do Contrato.
        /// </summary>
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private DateTime dataAlteracao;
        /// <summary>
        /// Propriedade relacionada a Data de Alteração do Historico do Contrato.
        /// </summary>
        public DateTime DataAlteracao
        {
            get { return dataAlteracao; }
            set { dataAlteracao = value; }
        }

        private string descricao;
        /// <summary>
        /// Propriedade relacionada a Descrição do que foi modificado do Historico do Contrato.
        /// </summary>
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        /// <summary>
        /// Construtor padrão do Historico da Parcela, Inicializando o Contrato e o Usuario.
        /// </summary>
        public HistoricoContrato()
        {
            this.contrato = new Contrato();
            this.contratoHistorico = new Contrato();
            this.usuario = new Usuario();
        }
    }
}
