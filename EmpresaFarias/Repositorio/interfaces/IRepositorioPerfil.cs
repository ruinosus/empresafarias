using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;

namespace Repositorio.interfaces
{
    /// <summary>
    /// Interface que representa os metodos de acesso a dados do Perfil.
    /// </summary>
    public interface IRepositorioPerfil
    {
        /// <summary>
        /// Metodo responsavel por inserir um Perfil de um Usuario.
        /// </summary>
        /// <param name="UsuarioId">Id do Usuario.</param>
        /// <param name="PerfilId"> Id do Perfil.</param>
        void Inserir(int UsuarioId, int PerfilId);

        /// <summary>
        /// Metodo responsavel por remover um Perfil de um Usuario.
        /// </summary>
        /// <param name="UsuarioId">Id do Usuario.</param>
        /// <param name="PerfilId"> Id do Perfil.</param>
        void Remover(int UsuarioId, int PerfilId);

        /// <summary>
        /// Metodo responsavel por consultar um Perfil.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um Perfil com o Id informado.</returns>
        Perfil Consultar(int id);

        /// <summary>
        /// Metodo responsavel por consultar todos os Perfis cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os Perfis cadastrados.</returns>
        List<Perfil> Consultar();

        /// <summary>
        /// Metodo responsavel por consultar todos os Perfis cadastrados.
        /// </summary>
        /// <param name="usuario">Usuario para pesquisa.</param>
        /// <returns>retorna uma Lista com todos os Perfis cadastrados do Usuario.</returns>
        List<Perfil> Consultar(Usuario usuario);
    }
}
