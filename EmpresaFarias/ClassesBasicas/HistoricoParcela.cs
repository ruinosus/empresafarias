using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesBasicas
{
    /// <summary>
    /// Classe que representa os Historicos de Mudanças de uma Parcela.
    /// </summary>
    public class HistoricoParcela : Parcela
    {
        private Parcela parcela;
        /// <summary>
        /// Propriedade relacionada a Parcela monitorada pelo Historico de Mudanças.
        /// </summary>
        public Parcela Parcela
        {
            get { return parcela; }
            set { parcela = value; }
        }

         private Usuario usuario;
        /// <summary>
         /// Propriedade relacionada ao Usuario que efetuou a mudança do Historico da Parcela.
        /// </summary>
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private DateTime dataAlteracao;
        /// <summary>
        /// Propriedade relacionada a Data de Alteração do Historico da Parcela.
        /// </summary>
        public DateTime DataAlteracao
        {
            get { return dataAlteracao; }
            set { dataAlteracao = value; }
        }

        private string descricao;
        /// <summary>
        /// Propriedade relacionada a Descrição do que foi modificado do Historico da Parcela.
        /// </summary>
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        /// <summary>
        /// Construtor padrão do Historico da Parcela, Inicializando a Parcela e o Usuario.
        /// </summary>
        public HistoricoParcela()
        {
            this.parcela = new Parcela();
            this.usuario = new Usuario();
        }
    }
}
