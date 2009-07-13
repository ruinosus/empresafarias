using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesBasicas
{
    /// <summary>
    /// Enum que representa os Status referente a um Dependente.
    /// </summary>
    public enum StatusDependente
    {
        Ativo = 1,
        InativoFaltaPagamento,
        InativoObito,
        InativoCancelamentoContrato,
        InativoExlusao
    }
    /// <summary>
    /// Classe que representa os Dependentes que um Titular poderá ter.
    /// </summary>
    public class Dependente
    {
        private int id;
        /// <summary>
        /// Propriedade relacionada ao Id do Dependente.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string nome;
        /// <summary>
        /// Propriedade relacionada ao Nome do Dependente.
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private string religiao;
        /// <summary>
        /// Propriedade relacionada a Religiao do Dependente.
        /// </summary>
        public string Religiao
        {
            get { return religiao; }
            set { religiao = value; }
        }

        
        private DateTime dataNascimento;
        /// <summary>
        /// Propriedade relacionada a Data de Nascimento do Dependente.
        /// </summary>
        public DateTime DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }

        private string parentesco;
        /// <summary>
        /// Propriedade relacionada ao Parentesco do Dependente.
        /// </summary>
        public string Parentesco
        {
            get { return parentesco; }
            set { parentesco = value; }
        }
        private int percentualCobertura;
        /// <summary>
        /// Propriedade relacionada ao Percentual de Cobertura do Dependente.
        /// </summary>
        public int PercentualCobertura
        {
            get { return percentualCobertura; }
            set { percentualCobertura = value; }
        }

        private StatusDependente status;
        /// <summary>
        /// Propriedade relacionada ao Status do Dependente.
        /// </summary>
        public StatusDependente Status
        {
            get { return status; }
            set { status = value; }
        }

        private int titularId;
        /// <summary>
        /// Propriedade relacionada ao Id do Titular do Contrato.
        /// </summary>
        public int TitularId
        {
            get { return titularId; }
            set { titularId = value; }
        }

        public override bool Equals(object obj)
        {
            bool resultado = false;

            if(obj is Dependente)
            {
                Dependente d = obj as Dependente;
                if (d.Id == this.id)
                    resultado = true;
            }
            return resultado;
        }
     }
}
