using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.interfaces;
using ClassesBasicas;

namespace Negocio.controladores
{
    /// <summary>
    /// Classe Reponsavel por todas as regras de Negocio do Titular.
    /// </summary>
    public class ControladorTitular
    {
        private ControladorDependente contDependente;
        private ControladorContrato contContrato;
        private ControladorCidadeEstado contCidadeEstado;
        private IRepositorioTitular repTitular;
        private IRepositorioHistoricoTitular repHistoricoTitular;
        private ControladorUsuario contUsuario;
        

        /// <summary>
        /// Construtor da Classe ControladorTitular
        /// </summary>
        /// <param name="repTitular">Recebe um objeto que implemente IRepositorioTitular.</param>
        /// <param name="contContrato">>Recebe um objeto do tipo ControladorContrato.</param>
        /// <param name="contDependente">>Recebe um objeto do tipo ControladorDependente.</param>
        /// <param name="contCidadeEstado">>Recebe um objeto do tipo ControladorCidadeEstado.</param>
        /// <param name="repHistoricoTitular">Recebe um objeto ue implemente IRepositorioHistoricoTitular.</param>
        /// <param name="contUsuario">Recebe um objeto do Tipo ControladorUsuario.</param>
        public ControladorTitular(IRepositorioTitular repTitular,
                                  ControladorContrato contContrato,
                                  ControladorDependente contDependente,
                                  ControladorCidadeEstado contCidadeEstado,
                                  IRepositorioHistoricoTitular repHistoricoTitular,
                                  ControladorUsuario contUsuario)  
        {
            this.contContrato = contContrato;
            this.contDependente = contDependente;
            this.contCidadeEstado = contCidadeEstado;
            this.repTitular = repTitular;
            this.repHistoricoTitular = repHistoricoTitular;
            this.contUsuario = contUsuario;
        }

        /// <summary>
        /// Metodo responsavel por inserir um Titular.
        /// </summary>
        /// <param name="titular">Objeto do tipo Titular a ser inserido</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o objeto seja nulo.</exception>
        /// <returns>retorna o Titular inserido.</returns>
        public Titular Inserir(Titular titular, Usuario usuario)
        {
            if (titular == null)
                throw new ExcecaoNegocio("Valor Inválido.");
            Titular t = this.repTitular.Inserir(titular);
            HistoricoTitular ht = new HistoricoTitular();
            ht.DataAlteracao = new DateTime();
            ht.DataAlteracao = DateTime.Now;
            ht.Usuario = usuario;
            ht.Descricao = "Inserido";
            ht.TitularHistorico = t;
            ht.Titular = t;

            this.InserirHistorico(ht);
            return t;
        }

        /// <summary>
        /// Metodo responsavel por alterar um Titular.
        /// </summary>
        /// <param name="dependente">Objeto do tipo Titular a ser alterado</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o objeto seja nulo ou o Titular não seja encontrado.</exception>
        public void Alterar(Titular titular, Usuario usuario)
        {
            Titular titularAntigo = this.Consultar(titular.Id);
            if (titularAntigo != null && titular != null)
                this.repTitular.Alterar(titular);
            else
                throw new ExcecaoNegocio("Titular não existente.");

            HistoricoTitular ht = new HistoricoTitular();
            ht.DataAlteracao = new DateTime();
            ht.DataAlteracao = DateTime.Now;
            ht.Usuario = usuario;
            string descricao = "Alterado\n";

            if (titularAntigo.DataNascimento != titular.DataNascimento)
            {
                descricao += "Data de Nascimento\n";
            }
            if (titularAntigo.Nome != titular.Nome)
            {
                descricao += "Nome\n";
            }
            if (titularAntigo.CidadeNaturalidade.Id != titular.CidadeNaturalidade.Id)
            {
                descricao += "Cidade Naturalidade\n";
            }
            if (titularAntigo.Cpf != titular.Cpf)
            {
                descricao += "Cpf\n";
            }
            if (titularAntigo.Endereco.Bairro != titular.Endereco.Bairro)
            {
                descricao += "Bairro\n";
            }
            if (titularAntigo.Endereco.Cep != titular.Endereco.Cep)
            {
                descricao += "Cep\n";
            }
            if (titularAntigo.Endereco.Cidade.Id != titular.Endereco.Cidade.Id)
            {
                descricao += "Cidade\n";
            }
            if (titularAntigo.Endereco.Complemento != titular.Endereco.Complemento)
            {
                descricao += "Complemento\n";
            }
            if (titularAntigo.Endereco.Logradouro != titular.Endereco.Logradouro)
            {
                descricao += "Logradouro\n";
            }
            if (titularAntigo.Endereco.Numero != titular.Endereco.Numero)
            {
                descricao += "Numero\n";
            }
            if (titularAntigo.EstadoCivil != titular.EstadoCivil)
            {
                descricao += "Estado Civil\n";
            }
            if (titularAntigo.Rg.Numero != titular.Rg.Numero)
            {
                descricao += "Numero do Rg\n";
            }
            if (titularAntigo.Rg.OrgaoExpeditor != titular.Rg.OrgaoExpeditor)
            {
                descricao += "Orgao Expeditor\n";
            }
            if (titularAntigo.Rg.DataExpedicao != titular.Rg.DataExpedicao)
            {
                descricao += "Data Expedicao\n";
            }
            if (titularAntigo.Sexo != titular.Sexo)
            {
                descricao += "Sexo\n";
            }
            if (titularAntigo.TelefoneCelular != titular.TelefoneCelular)
            {
                descricao += "Telefone Celular\n";
            }
            if (titularAntigo.TelefoneResidencial != titular.TelefoneResidencial)
            {
                descricao += "Telefone Residencial\n";
            }

            if (titularAntigo.Status != titular.Status)
            {
                descricao += "Status\n";
            }



            ht.Descricao = descricao;
            ht.TitularHistorico = titular;
            ht.Titular = titular;

            this.InserirHistorico(ht);
        }

        /// <summary>
        /// Metodo responsavel por remover um Titular.
        /// </summary>
        /// <param name="id">Id do Titular a ser removido.</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o Titular não seja encontrado.</exception>
        public void Remover(int id)
        {
            if (this.Consultar(id) != null)
                this.repTitular.Remover(id);
            else
                throw new ExcecaoNegocio("Titular não existente.");
        }

        /// <summary>
        /// Metodo responsavel por consultar um Titular.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um Titular com o Id informado.</returns>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o Titular não seja encontrado.</exception>
        public Titular Consultar(int id)
        {
            Titular titular = this.repTitular.Consultar(id);

            if (titular == null)
                throw new ExcecaoNegocio("Titular não existente.");
            return this.MontarTitular(titular);
        }

        /// <summary>
        /// Metodo responsavel por consultar todos os Titulares cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os Titulares cadastrados.</returns>
        public List<Titular> Consultar()
        {
            List<Titular> titulares = this.repTitular.Consultar();

            for (int i = 0; i < titulares.Count; i++)
            {
                titulares[i] = this.MontarTitular(titulares[i]);
            }

            return titulares;
        }

        /// <summary>
        /// Metodo responsavel por montar um Titular juntamente com seus Dependentes e seus Contratos.
        /// </summary>
        /// <param name="titular">Titular a ser montado.</param>
        /// <returns>Titular contendo todos os seus Dependentes e seus Contratos.</returns>
        private Titular MontarTitular(Titular titular)
        {
            titular.Dependentes = this.contDependente.Consultar(titular);
            titular.Contratos = this.contContrato.Consultar(titular);
            titular.CidadeNaturalidade = this.contCidadeEstado.Consultar(titular.CidadeNaturalidade.Id);
            titular.Endereco.Cidade = this.contCidadeEstado.Consultar(titular.Endereco.Cidade.Id);
            return titular;
        }

        /// <summary>
        /// Metodo responsavel por inserir um HistoricoTitular.
        /// </summary>
        /// <param name="historicoTitular">Objeto do tipo HistoricoTitular a ser inserido</param>
        /// <returns>retorna o HistoricoTitular inserido.</returns>
        public HistoricoTitular InserirHistorico(HistoricoTitular historicoTitular)
        {
            return this.repHistoricoTitular.Inserir(historicoTitular);
        }

        /// <summary>
        /// Metodo responsavel por consultar um HistoricoTitular.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um HistoricoTitular com o Id informado.</returns>
        public HistoricoTitular ConsultarHistorico(int id)
        {
            return this.repHistoricoTitular.Consultar(id);
        }

        /// <summary>
        /// Metodo responsavel por consultar todos os HistoricosTitular cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os HistoricosTitular cadastrados.</returns>
        public List<HistoricoTitular> ConsultarHistorico()
        {
            return this.repHistoricoTitular.Consultar();
        }

        /// <summary>
        /// Metodo responsavel por consultar uma lista contendo todos os HistoricosParcela do Titular Informado.
        /// </summary>
        /// <param name="titular">Objeto do tipo Titular a ser pesquisado.</param>
        /// <returns>retorna uma lista contendo todos os HistoricosDependente da Titular Informada.</returns>
        public List<HistoricoTitular> ConsultarHistorico(Titular titular)
        {
            return this.repHistoricoTitular.Consultar(titular);
        }
    }
}
