using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;

namespace Repositorio.interfaces
{
    /// <summary>
    /// Interface que representa os metodos de acesso a dados do Titular.
    /// </summary>
    public interface IRepositorioTitular
    {
        /// <summary>
        /// Metodo responsavel por inserir um Titular.
        /// </summary>
        /// <param name="titular">Objeto do tipo Titular a ser inserido</param>
        /// <returns>retorna o Titular inserido.</returns>
        Titular Inserir(Titular titular);
        /// <summary>
        /// Metodo responsavel por alterar um Titular.
        /// </summary>
        /// <param name="titular">Objeto do tipo Titular a ser alterado</param>
        void Alterar(Titular titular);
        /// <summary>
        /// Metodo responsavel por remover um Titular.
        /// </summary>
        /// <param name="id">Id do Titular a ser removido.</param>
        void Remover(int id);
        /// <summary>
        /// Metodo responsavel por consultar um Titular.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um Titular com o Id informado.</returns>
        Titular Consultar(int id);
        /// <summary>
        /// Metodo responsavel por consultar todos os Titulares cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os Titulares cadastrados.</returns>
        List<Titular> Consultar();        
    }
}
