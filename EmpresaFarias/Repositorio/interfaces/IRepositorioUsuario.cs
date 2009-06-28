using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;

namespace Repositorio.interfaces
{
    /// <summary>
    /// Interface que representa os metodos de acesso a dados do Usuario.
    /// </summary>
    public interface IRepositorioUsuario
    {
        /// <summary>
        /// Metodo responsavel por inserir um Usuario.
        /// </summary>
        /// <param name="usuario">Objeto do tipo Usuario a ser inserido</param>
        /// <returns>retorna o Usuario inserido.</returns>
        Usuario Inserir(Usuario usuario);

        /// <summary>
        /// Metodo responsavel por alterar um Usuario.
        /// </summary>
        /// <param name="usuario">Objeto do tipo Usuario a ser alterado</param>
        void Alterar(Usuario usuario);

        /// <summary>
        /// Metodo responsavel por alterar a senha de um Usuario.
        /// </summary>
        /// <param name="id">Id do Usuario.</param>
        /// <param name="senha">Nova Senha.</param>
        void Alterar(int id, string senha);

        /// <summary>
        /// Metodo responsavel por remover um Usuario.
        /// </summary>
        /// <param name="id">Id do Usuario a ser removido.</param>
        void Remover(int id);

        /// <summary>
        /// Metodo responsavel por consultar um Usuario.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um Usuario com o Id informado.</returns>
        Usuario Consultar(int id);

        /// <summary>
        /// Metodo responsavel por consultar um Usuario pelo seu Login e senha.
        /// </summary>
        /// <param name="login">Login a ser pesquisado.</param>
        /// <param name="senha">Senha a ser pesquisado.</param>
        /// <returns>Objeto do tipo Usuario.</returns>
        Usuario Consultar(string login, string senha);

        /// <summary>
        /// Metodo responsavel por consultar um Usuario pelo seu Login.
        /// </summary>
        /// <param name="login">Login a ser pesquisado.</param>
        /// <returns>Objeto do tipo Usuario.</returns>
        Usuario Consultar(string login);

        /// <summary>
        /// Metodo reponsavel por consultar todos os Usuarios.
        /// </summary>
        /// <returns>Lista com todo os Usuarios cadastrados.</returns>
        List<Usuario> Consultar();
    }
}
