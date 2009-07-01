using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.interfaces;
using ClassesBasicas;

namespace Negocio.controladores
{
    /// <summary>
    /// Classe Reponsavel por todas as regras de Negocio do Usuario.
    /// </summary>
    public class ControladorUsuario
    {
        private IRepositorioUsuario repUsuario;
        private IRepositorioPerfil repPerfil;

        /// <summary>
        /// Construtor da Classe ControladorUsuario.
        /// </summary>
        /// <param name="repUsuario">Recebe um objeto do tipo IRepositorioUsuario.</param>
        /// <param name="repPerfil">Recebe um objeto do tipo IRepositorioPerfil.</param>
        public ControladorUsuario(IRepositorioUsuario repUsuario,
                                  IRepositorioPerfil repPerfil)
        {
            this.repUsuario = repUsuario;
            this.repPerfil = repPerfil;
        }

        /// <summary>
        /// Insere um novo Usuario no Banco de Dados.
        /// </summary>
        /// <param name="usuario">
        /// Objeto do tipo Usuario que vai ser inserido no Banco de Dados.
        /// </param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o objeto seja nulo ou o login seja igual a algum login já cadastrado.</exception>
        public void Inserir(Usuario usuario)
        {
            if (usuario == null)
                throw new ExcecaoNegocio("Valor inválido.");
            if ((this.Consultar(usuario.Login)))
                throw new ExcecaoNegocio("Login já informado, por favor informe outro.");

           usuario.Status = StatusUsuario.Ativo;
           Usuario u =  this.repUsuario.Inserir(usuario);
            if(u.Perfis.Count > 0)
            {
                for (int i = 0; i < u.Perfis.Count;i++ )
                {
                    this.InserirPerfil(u.Id, u.Perfis[i].Id);
                }
            }

        }

        /// <summary>
        /// Consulta um Usuario pelo seu Id.
        /// </summary>
        /// <param name="id">id do Usuario.</param>
        /// <returns>Usuario.</returns>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o id não existir no Banco de Dados. </exception>
        public Usuario Consultar(int id)
        {
            Usuario usuario = this.repUsuario.Consultar(id);
            if (usuario == null)
                throw new ExcecaoNegocio("Usuario não existente.");
            return this.MontarUsuario(usuario);
        }

        /// <summary>
        /// Consulta um Usuario por seu login e sua senha.
        /// </summary>
        /// <param name="login">login único do Usuario.</param>
        /// <param name="senha">senha do Usuario.</param>
        /// <returns>Usuario.</returns>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o login ou senha sejam nulos ou não existirem no Banco de Dados. </exception>
        public Usuario Consultar(String login, String senha)
        {
            if (login == null || senha == null)
                throw new ExcecaoNegocio("Login/Senha incorretos.");

            Usuario usuario = this.repUsuario.Consultar(login, senha);
            if (usuario == null)
                throw new ExcecaoNegocio("Login/Senha incorretos.");
            return this.MontarUsuario(usuario);
        }

        /// <summary>
        /// Verifica se o login informado já existe no Banco de dados.
        /// </summary>
        /// <param name="login">login para pesquisa.</param>
        /// <returns>verdadeiro caso o login exista e falso caso contrário.</returns>
        public bool Consultar(String login)
        {
            bool resultado = false;
            Usuario usuario = this.repUsuario.Consultar(login);
            if (usuario != null)
                resultado = true;
            return resultado;
        }

        /// <summary>
        /// Consulta todos os Usuarios Cadastrados.
        /// </summary>
        /// <returns>Lista contendo todos os Usuarios cadastrados.</returns>
        public List<Usuario> Consultar()
        {
            List<Usuario> usuarios = this.repUsuario.Consultar();

            var resultado = from u in usuarios
                            where u.Status == StatusUsuario.Ativo
                            select u;
            usuarios = resultado.ToList();
            for (int i = 0; i < usuarios.Count; i++)
            {
                usuarios[i] = this.MontarUsuario(usuarios[i]);
            }

            return usuarios;
        }

        /// <summary>
        /// Remove um Usuario do Bando de Dados.
        /// </summary>
        /// <param name="id">id do Usuario.</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o id não existir no Banco de Dados. </exception>
        public void Remover(int id)
        {
            if (this.Consultar(id) != null)
                this.repUsuario.Remover(id);
            else
                throw new ExcecaoNegocio("Usuario não existente.");
        }

        /// <summary>
        /// Altera um Usuario já cadastrado no sistema.
        /// </summary>
        /// <param name="usuario">Objeto do tipo Usuario que vai ser alterado.</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso objeto Usuario seja nulo ou o seu id não existir no Banco de Dados. </exception>
        public void Alterar(Usuario usuario)
        {
            if (this.Consultar(usuario.Id) != null && usuario != null)
                this.repUsuario.Alterar(usuario);
            else
                throw new ExcecaoNegocio("Usuario não existente.");

            Usuario u = usuario;
            if (u.Perfis.Count > 0)
            {
                this.repPerfil.Remover(u);
                for (int i = 0; i < u.Perfis.Count; i++)
                {
                    this.InserirPerfil(u.Id, u.Perfis[i].Id);
                }
            }
            else
            {
                this.repPerfil.Remover(u);
            }
        }

        /// <summary>
        /// Altera a senha de um Usuario.
        /// </summary>
        /// <param name="id">id do Usuario.</param>
        /// <param name="senha">nova senha a ser alterada.</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso id não existir no Banco de Dados ou a senha for nula. </exception>
        public void Alterar(int id, String senha)
        {
            if (this.Consultar(id) != null && senha != null)
                this.repUsuario.Alterar(id, senha);
            else
                throw new ExcecaoNegocio("Usuario não existente.");
        }

        /// <summary>
        /// Metodo responsavel por montar um Usuario.
        /// </summary>
        /// <param name="titular">Usuario a ser montado.</param>
        /// <returns>Usuario.</returns>
        private Usuario MontarUsuario(Usuario usuario)
        {
            usuario.Perfis = this.ConsultarPerfil(usuario);
            return usuario;
        }

        /// <summary>
        /// Metodo responsavel por inserir um Perfil de um Usuario.
        /// </summary>
        /// <param name="UsuarioId">Id do Usuario.</param>
        /// <param name="PerfilId"> Id do Perfil.</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o objeto seja nulo ou o login seja igual a algum login já cadastrado.</exception>
        public void InserirPerfil(int UsuarioId, int PerfilId)
        {
            this.repPerfil.Inserir(UsuarioId,PerfilId);
        }

        /// <summary>
        /// Metodo responsavel por remover um Perfil de um Usuario.
        /// </summary>
        /// <param name="UsuarioId">Id do Usuario.</param>
        /// <param name="PerfilId"> Id do Perfil.</param>
        public void RemoverPerfil(int UsuarioId, int PerfilId)
        {
            this.repPerfil.Remover(UsuarioId, PerfilId);
        }

        /// <summary>
        /// Metodo responsavel por remover um Perfil de um Usuario.
        /// </summary>
        /// <param name="usuario">Usuario.</param>
        public void Remover(Usuario usuario)
        {
            this.repPerfil.Remover(usuario);
        }

        /// <summary>
        /// Metodo responsavel por consultar todos os Perfis cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os Perfis cadastrados.</returns>
        public List<Perfil> ConsultarPerfil()
        {
            return this.repPerfil.Consultar();
        }

        /// <summary>
        /// Metodo responsavel por consultar todos os Perfis cadastrados.
        /// </summary>
        /// <param name="usuario">Usuario para pesquisa.</param>
        /// <returns>retorna uma Lista com todos os Perfis cadastrados do Usuario.</returns>
        public List<Perfil> ConsultarPerfil(Usuario usuario)
        {
            return this.repPerfil.Consultar(usuario);
        }
    }
}
