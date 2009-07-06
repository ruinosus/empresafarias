using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesBasicas
{
    /// <summary>
    /// Enum que representa os Status referente a um Titular
    /// </summary>
    public enum StatusTitular
    {
        Ativo = 1,
        InativoFaltaPagamento,
        InativoObito,
        InativoCancelamentoContrato,
        InativoExlusao
    }
    /// <summary>
    /// Classe que representa um Titular.
    /// </summary>
    public class Titular
    {
        private int id;
        /// <summary>
        /// Propriedade relacionada ao Id do Titular.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string nome;
        /// <summary>
        /// Propriedade relacionada ao Nome do Titular.
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private string religiao;
        /// <summary>
        /// Propriedade relacionada a Religiao do Titular.
        /// </summary>
        public string Religiao
        {
            get { return religiao; }
            set { religiao = value; }
        }

        private DateTime dataNascimento;
        /// <summary>
        /// Propriedade relacionada a Data de Nascimento do Titular.
        /// </summary>
        public DateTime DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }

        private char sexo;
        /// <summary>
        /// Propriedade relacionada ao Sexo do Titular.
        /// </summary>
        public char Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        private string estadoCivil;
        /// <summary>
        /// Propriedade relacionada ao Estado Civil do Titular.
        /// </summary>
        public string EstadoCivil
        {
            get { return estadoCivil; }
            set { estadoCivil = value; }
        }

        private string cpf;
        /// <summary>
        /// Propriedade relacionada ao Cpf do Titular.
        /// </summary>
        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        private Endereco endereco;
        /// <summary>
        /// Propriedade relacionada ao Endereco do Titular.
        /// </summary>
        public Endereco Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        private Cidade cidadeNaturalidade;
        /// <summary>
        /// Propriedade relacionada a Cidade de onde o Titular Nasceu.
        /// </summary>
        public Cidade CidadeNaturalidade
        {
            get { return cidadeNaturalidade; }
            set { cidadeNaturalidade = value; }
        }

        private string telefoneResidencial;
        /// <summary>
        /// Propriedade relacionada ao Telefone Residencial do Titular.
        /// </summary>
        public string TelefoneResidencial
        {
            get { return telefoneResidencial; }
            set { telefoneResidencial = value; }
        }

        private string telefoneCelular;
        /// <summary>
        /// Propriedade relacionada ao Telefone Celular do Titular.
        /// </summary>
        public string TelefoneCelular
        {
            get { return telefoneCelular; }
            set { telefoneCelular = value; }
        }

        private Rg rg;
        /// <summary>
        /// Propriedade relacionada ao Rg do Titular.
        /// </summary>
        public Rg Rg
        {
            get { return rg; }
            set { rg = value; }
        }
        

        private StatusTitular status;
        /// <summary>
        /// Propriedade relacionada ao Status do Titular.
        /// </summary>
        public StatusTitular Status
        {
            get { return status; }
            set { status = value; }
        }

        private List<Contrato> contratos;
        /// <summary>
        /// Propriedade relacionada aos Contratos do Titular.
        /// </summary>
        public List<Contrato> Contratos
        {
            get { return contratos; }
            set { contratos = value; }
        }

        private List<Dependente> dependentes;
        /// <summary>
        /// Propriedade relacionada aos Dependentes do Titular.
        /// </summary>
        public List<Dependente> Dependentes
        {
            get { return dependentes; }
            set { dependentes = value; }
        }
        /// <summary>
        /// Construtor padrão do Titular, inicializando o Endereco, a Cidade Natural, o Rg, os Contratos e os Dependentes.
        /// </summary>
        public Titular()
        {
            this.endereco = new Endereco();
            this.cidadeNaturalidade = new Cidade();
            this.rg = new Rg();
            this.contratos = new List<Contrato>();
            this.dependentes = new List<Dependente>();
        }


    }
}
