using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesBasicas
{
    /// <summary>
    /// Classe que representa os Historicos de Mudanças de um Titular.
    /// </summary>
    public class HistoricoTitular
    {
        private Titular titular;
        /// <summary>
        /// Propriedade relacionada ao Titular monitorado pelo Historico de Mudanças.
        /// </summary>
        public Titular Titular
        {
            get { return titular; }
            set { titular = value; }
        }

        private Titular titularHistorico;
        /// <summary>
        /// Propriedade relacionada ao TitularHistorico.
        /// </summary>
        public Titular TitularHistorico
        {
            get { return titularHistorico; }
            set { titularHistorico = value; }
        }

         private Usuario usuario;
        /// <summary>
        /// Propriedade relacionada ao Usuario que efetuou a mudança do Historico do Titular.
        /// </summary>
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private DateTime dataAlteracao;
        /// <summary>
        /// Propriedade relacionada a Data de Alteração do Historico do Titular.
        /// </summary>
        public DateTime DataAlteracao
        {
            get { return dataAlteracao; }
            set { dataAlteracao = value; }
        }

        private string descricao;
        /// <summary>
        /// Propriedade relacionada a Descrição do que foi modificado do Historico do Titular.
        /// </summary>
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        /// <summary>
        /// Construtor padrão do Historico do Dependente, Inicializando o Titular e o Usuario.
        /// </summary>
        public HistoricoTitular()
        {
            this.titular = new Titular();
            this.titularHistorico = new Titular();
            this.usuario = new Usuario();
        }
    }
}
