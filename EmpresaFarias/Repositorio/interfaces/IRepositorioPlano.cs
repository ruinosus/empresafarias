using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;

namespace Repositorio.interfaces
{
    /// <summary>
    /// Interface que representa os metodos de acesso a dados do Plano.
    /// </summary>
    public interface IRepositorioPlano
    {
        /// <summary>
        /// Metodo responsavel por inserir um Plano.
        /// </summary>
        /// <param name="plano">Objeto do tipo Plano a ser inserido</param>
        void Inserir(Plano plano);
        /// <summary>
        /// Metodo responsavel por alterar um Plano.
        /// </summary>
        /// <param name="plano">Objeto do tipo Plano a ser alterado</param>
        void Alterar(Plano plano);
        /// <summary>
        /// Metodo responsavel por remover um Plano.
        /// </summary>
        /// <param name="id">Id do Plano a ser removido.</param>
        void Remover(int id);
        /// <summary>
        /// Metodo responsavel por consultar um Plano.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um Plano com o Id informado.</returns>
        Plano Consultar(int id);
        /// <summary>
        /// Metodo responsavel por consultar todos os Planos cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os Planos cadastrados.</returns>
        List<Plano> Consultar();
    }
}
