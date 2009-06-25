using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;

namespace Repositorio.interfaces
{
    /// <summary>
    /// Interface que representa os metodos de acesso a dados do Dependente.
    /// </summary>
    public interface IRepositorioDependente
    {
        /// <summary>
        /// Metodo responsavel por inserir um Dependente.
        /// </summary>
        /// <param name="dependente">Objeto do tipo Dependente a ser inserido</param>
        /// <param name="TitularId">Id do Titular do Dependente.</param>
        void Inserir(Dependente dependente, int TitularId);
        /// <summary>
        /// Metodo responsavel por alterar um Dependente.
        /// </summary>
        /// <param name="dependente">Objeto do tipo Dependente a ser alterado</param>
        /// <param name="TitularId">Id do Titular do Dependente.</param>
        void Alterar(Dependente dependente, int TitularId);
        /// <summary>
        /// Metodo responsavel por remover um Dependente.
        /// </summary>
        /// <param name="id">Id do Dependente a ser removido.</param>
        void Remover(int id);
        /// <summary>
        /// Metodo responsavel por consultar um Dependente.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um Dependente com o Id informado.</returns>
        Dependente Consultar(int id);
        /// <summary>
        /// Metodo responsavel por consultar todos os Dependentes cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os Dependentes cadastrados.</returns>
        List<Dependente> Consultar();
        /// <summary>
        /// Metodo responsavel por consultar os Dependentes de um Titular.
        /// </summary>
        /// <param name="titular">Titular a ser utilizado como pesquisa.</param>
        /// <returns>retorna uma Lista com todos os Dependentes encontrados do Titular informado.</returns>
        List<Dependente> Consultar(Titular titular);
    }
}
