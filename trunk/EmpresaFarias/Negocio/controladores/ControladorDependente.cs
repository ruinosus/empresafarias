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
        /// <summary>
        /// Construtor da Classe ControladorDependente
        /// </summary>
        /// <param name="repDependente">Recebe um objeto que implemente IRepositorioDependente.</param>
        public ControladorDependente(IRepositorioDependente repDependente) 
        {
            this.repDependente = repDependente;	
        }

        /// <summary>
        /// Metodo responsavel por inserir um Dependente.
        /// </summary>
        /// <param name="dependente">Objeto do tipo Dependente a ser inserido</param>
        /// <param name="TitularId">Id do Titular do Dependente.</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o objeto seja nulo.</exception>
        /// <returns>retorna o Dependente inserido.</returns>  
        public Dependente Inserir(Dependente dependente, int TitularId)
        {
            if (dependente == null)
                throw new ExcecaoNegocio("Valor Inválido.");
            return this.repDependente.Inserir(dependente, TitularId);
        }
        /// <summary>
        /// Metodo responsavel por alterar um Dependente.
        /// </summary>
        /// <param name="dependente">Objeto do tipo Dependente a ser alterado</param>
        /// <param name="TitularId">Id do Titular do Dependente.</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o objeto seja nulo ou o Dependente não seja encontrado.</exception>
        public void Alterar(Dependente dependente, int TitularId)
        {
            if (this.Consultar(dependente.Id) != null && dependente != null)
                this.repDependente.Alterar(dependente, TitularId);
            else
                throw new ExcecaoNegocio("Dependente não existente.");
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
    }
}
