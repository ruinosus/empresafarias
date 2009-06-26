using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.interfaces;
using ClassesBasicas;

namespace Negocio.controladores
{
    /// <summary>
    /// Classe Reponsavel por todas as regras de Negocio do Plano.
    /// </summary>
    public class ControladorPlano
    {
        private IRepositorioPlano repPlano;
        /// <summary>
        /// Construtor da Classe ControladorPlano
        /// </summary>
        /// <param name="repPlano">Recebe um objeto que implemente IRepositorioPlano.</param>
        public ControladorPlano(IRepositorioPlano repPlano) 
        {
            this.repPlano = repPlano;	
        }

        /// <summary>
        /// Metodo responsavel por inserir um Plano.
        /// </summary>
        /// <param name="plano">Objeto do tipo Plano a ser inserido.</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o objeto seja nulo.</exception>
        public void Inserir(Plano plano)
        {
            if (plano == null)
                throw new ExcecaoNegocio("Valor Inválido.");
            this.repPlano.Inserir(plano);
        }
        /// <summary>
        /// Metodo responsavel por alterar um Plano.
        /// </summary>
        /// <param name="plano">Objeto do tipo Plano a ser alterado</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o objeto seja nulo ou o Plano não seja encontrado.</exception>
        public void Alterar(Plano plano)
        {
            if (this.Consultar(plano.Id) != null && plano != null)
                this.repPlano.Alterar(plano);
            else
                throw new ExcecaoNegocio("Plano não existente.");
        }
        /// <summary>
        /// Metodo responsavel por remover um Plano.
        /// </summary>
        /// <param name="id">Id do Plano a ser removido.</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o Plano não seja encontrado.</exception>
        public void Remover(int id)
        {
            if (this.Consultar(id) != null)
                this.repPlano.Remover(id);
            else
                throw new ExcecaoNegocio("Plano não existente.");
        }
        /// <summary>
        /// Metodo responsavel por consultar um Plano.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um Plano com o Id informado.</returns>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o Plano não seja encontrado.</exception>
        public Plano Consultar(int id)
        {
            Plano plano = this.repPlano.Consultar(id);
            if (plano == null)
                throw new ExcecaoNegocio("Plano não existente.");
            return plano;
        }
        /// <summary>
        /// Metodo responsavel por consultar todos os Planos cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os Planos cadastrados.</returns>
        public List<Plano> Consultar()
        {
            return this.repPlano.Consultar();
        }
    }
}
