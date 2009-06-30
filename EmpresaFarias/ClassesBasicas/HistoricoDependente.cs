using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesBasicas
{
    /// <summary>
    /// Classe que representa os Historicos de Mudanças de um Dependente.
    /// </summary>
    public class HistoricoDependente 
    {
        private Dependente dependente;
        /// <summary>
        /// Propriedade relacionada ao Dependente monitorado pelo Historico de Mudanças.
        /// </summary>
        public Dependente Dependente
        {
            get { return dependente; }
            set { dependente = value; }
        }

        private Dependente dependenteHistorico;
        /// <summary>
        /// Propriedade relacionada ao DependenteHistorico.
        /// </summary>
        public Dependente DependenteHistorico
        {
            get { return dependenteHistorico; }
            set { dependenteHistorico = value; }
        }

         private Usuario usuario;
        /// <summary>
         /// Propriedade relacionada ao Usuario que efetuou a mudança do Historico do Dependente.
        /// </summary>
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private DateTime dataAlteracao;
        /// <summary>
        /// Propriedade relacionada a Data de Alteração do Historico do Dependente.
        /// </summary>
        public DateTime DataAlteracao
        {
            get { return dataAlteracao; }
            set { dataAlteracao = value; }
        }

        private string descricao;
        /// <summary>
        /// Propriedade relacionada a Descrição do que foi modificado do Historico do Dependente.
        /// </summary>
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        /// <summary>
        /// Construtor padrão do Historico do Dependente, Inicializando o Dependente e o Usuario.
        /// </summary>
        public HistoricoDependente()
        {
            this.dependente = new Dependente();
            this.dependenteHistorico = new Dependente();
            this.usuario = new Usuario();
        }
    }
}
