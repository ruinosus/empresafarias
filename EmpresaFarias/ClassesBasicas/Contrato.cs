using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesBasicas
{
    /// <summary>
    /// Enum que representa os Status referente a um Contrato.
    /// </summary>
    public enum StatusContrato
    {
        Ativo = 1,
        InativoFaltaPagamento,
        InativoObito,
        InativoCancelamentoContrato,
        InativoExlusao
    }
    /// <summary>
    /// Classe que representa um Contrato que um Titular poderá ter.
    /// </summary>
    public class Contrato
    {
        private int id;
        /// <summary>
        /// Propriedade relacionada ao Id do Contrato.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime dataInicio;
        /// <summary>
        /// Propriedade relacionada a Data de Inicio do Contrato.
        /// </summary>
        public DateTime DataInicio
        {
            get { return dataInicio; }
            set { dataInicio = value; }
        }

        private StatusContrato status;
        /// <summary>
        /// Propriedade relacionada ao Status do Contrato.
        /// </summary>
        public StatusContrato Status
        {
            get { return status; }
            set { status = value; }
        }

        private Plano plano;
        /// <summary>
        /// Propriedade relacionada ao Plano do Contrato.
        /// </summary>
        public Plano Plano
        {
            get { return plano; }
            set { plano = value; }
        }
        private List<Parcela> parcelas;
        /// <summary>
        /// Propriedade relacionada as Parcelas de um Contrato.
        /// </summary>
        public List<Parcela> Parcelas
        {
            get { return parcelas; }
            set { parcelas = value; }
        }
        /// <summary>
        /// Construtor Padrão que inicializa o Plano e as Parcelas.
        /// </summary>
        public Contrato()
        {
            this.plano = new Plano();
            this.parcelas = new List<Parcela>();           
        }
    }
}
