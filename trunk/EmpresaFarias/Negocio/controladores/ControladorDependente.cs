using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.interfaces;
using ClassesBasicas;

namespace Negocio.controladores
{
    /// <summary>
    /// Classe Reponsavel por todas as regras de Negocio do Dependente.
    /// </summary>
    public class ControladorDependente
    {
        private IRepositorioDependente repDependente;
        private IRepositorioHistoricoDependente repHistoricoDependente;
        private ControladorUsuario contUsuario;

        /// <summary>
        /// Construtor da Classe ControladorDependente
        /// </summary>
        /// <param name="repDependente">Recebe um objeto que implemente IRepositorioDependente.</param>
        /// <param name="repHistoricoDependente">Recebe um objeto ue implemente IRepositorioHistoricoDependente.</param>
        /// <param name="contUsuario">Recebe um objeto do Tipo ControladorUsuario.</param>
        public ControladorDependente(IRepositorioDependente repDependente,
                                     IRepositorioHistoricoDependente repHistoricoDependente,
                                     ControladorUsuario contUsuario) 
        {
            this.repDependente = repDependente;
            this.repHistoricoDependente = repHistoricoDependente;
            this.contUsuario = contUsuario;
        }

        /// <summary>
        /// Metodo responsavel por inserir um Dependente.
        /// </summary>
        /// <param name="dependente">Objeto do tipo Dependente a ser inserido</param>
        /// <param name="TitularId">Id do Titular do Dependente.</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o objeto seja nulo.</exception>
        /// <returns>retorna o Dependente inserido.</returns>  
        public Dependente Inserir(Dependente dependente, int TitularId, Usuario usuario)
        {
            if (dependente == null)
                throw new ExcecaoNegocio("Valor Inválido.");
            Dependente d = this.repDependente.Inserir(dependente, TitularId);

            HistoricoDependente hd = new HistoricoDependente();
            hd.DataAlteracao = new DateTime();
            hd.DataAlteracao = DateTime.Now;
            hd.Usuario = usuario;
            hd.Descricao = "Inserido";
            hd.DependenteHistorico = d;
            hd.Dependente = d;

            this.InserirHistorico(hd, TitularId);

            return d;
        }

        /// <summary>
        /// Metodo responsavel por alterar um Dependente.
        /// </summary>
        /// <param name="dependente">Objeto do tipo Dependente a ser alterado</param>
        /// <param name="TitularId">Id do Titular do Dependente.</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o objeto seja nulo ou o Dependente não seja encontrado.</exception>
        public void Alterar(Dependente dependente, int TitularId, Usuario usuario)
        {
            Dependente dependenteAntigo = this.Consultar(dependente.Id);
            if (dependenteAntigo != null && dependente != null)
                this.repDependente.Alterar(dependente, TitularId);
            else
                throw new ExcecaoNegocio("Dependente não existente.");

            HistoricoDependente hd = new HistoricoDependente();
            hd.DataAlteracao = new DateTime();
            hd.DataAlteracao = DateTime.Now;
            hd.Usuario = usuario;
            string descricao = "Alterado\n";

            if (dependenteAntigo.DataNascimento != dependente.DataNascimento)
            {
                descricao += "Data de Nascimento\n";
            }
            if (dependenteAntigo.Nome != dependente.Nome)
            {
                descricao += "Nome\n";
            }
            if (dependenteAntigo.Parentesco != dependente.Parentesco)
            {
                descricao += "Parentesco\n";
            }
            if (dependenteAntigo.PercentualCobertura != dependente.PercentualCobertura)
            {
                descricao += "Percentual de Cobertura\n";
            }
            if (dependenteAntigo.Religiao != dependente.Religiao)
            {
                descricao += "Religiao\n";
            }
            if (dependenteAntigo.Status != dependente.Status)
            {
                descricao += "Status\n";
            }



            hd.Descricao = descricao;
            hd.DependenteHistorico = dependente;
            hd.Dependente = dependente;

            this.InserirHistorico(hd, TitularId);
        }

        /// <summary>
        /// Metodo responsavel por remover um Dependente.
        /// </summary>
        /// <param name="id">Id do Dependente a ser removido.</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o Dependente não seja encontrado.</exception>
        public void Remover(int id)
        {
            if (this.Consultar(id) != null)
                this.repDependente.Remover(id);
            else
                throw new ExcecaoNegocio("Dependente não existente.");
        }

        /// <summary>
        /// Metodo responsavel por consultar um Dependente.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um Dependente com o Id informado.</returns>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o Dependente não seja encontrado.</exception>
        public Dependente Consultar(int id)
        {
            Dependente dependente = this.repDependente.Consultar(id);
            if (dependente == null)
                throw new ExcecaoNegocio("Dependente não existente.");
            return dependente;
        }

        /// <summary>
        /// Metodo responsavel por consultar todos os Dependentes cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os Dependentes cadastrados.</returns>
        public List<Dependente> Consultar()
        {
            return this.repDependente.Consultar();
        }

        /// <summary>
        /// Metodo responsavel por consultar os Dependentes de um Titular.
        /// </summary>
        /// <param name="titular">Titular a ser utilizado como pesquisa.</param>
        /// <returns>retorna uma Lista com todos os Dependentes encontrados do Titular informado.</returns>
        public List<Dependente> Consultar(Titular titular)
        {
            return this.repDependente.Consultar(titular);
        }

        /// <summary>
        /// Metodo responsavel por inserir um HistoricoDependente.
        /// </summary>
        /// <param name="historicoDependente">Objeto do tipo HistoricoDependente a ser inserido</param>
        /// <param name="TitularId">Id do Titular do HistoricoDependente.</param>
        /// <returns>retorna o HistoricoDependente inserido.</returns>
        public HistoricoDependente InserirHistorico(HistoricoDependente historicoDependente, int TitularId)
        {
            return this.repHistoricoDependente.Inserir(historicoDependente, TitularId);
        }

        /// <summary>
        /// Metodo responsavel por consultar um HistoricoDependente.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um HistoricoDependente com o Id informado.</returns>
        public HistoricoDependente ConsultarHistorico(int id)
        {
            return this.repHistoricoDependente.Consultar(id);
        }

        /// <summary>
        /// Metodo responsavel por consultar todos os HistoricosDependente cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os HistoricosDependente cadastrados.</returns>
        public List<HistoricoDependente> ConsultarHistorico()
        {
            return this.repHistoricoDependente.Consultar();
        }

        /// <summary>
        /// Metodo responsavel por consultar uma lista contendo todos os HistoricosDependente do Dependente Informado.
        /// </summary>
        /// <param name="dependente">Objeto do tipo Dependente a ser pesquisado.</param>
        /// <returns>retorna uma lista contendo todos os HistoricosDependente do Dependente Informado.</returns>
        public List<HistoricoDependente> ConsultarHistorico(Dependente dependente)
        {
            return this.repHistoricoDependente.Consultar(dependente);
        }
    }
}
