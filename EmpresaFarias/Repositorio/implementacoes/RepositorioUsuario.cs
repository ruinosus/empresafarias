using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;
using Repositorio.interfaces;
using System.Data.SqlClient;
using Excecoes;

namespace Repositorio.implementacoes
{
    /// <summary>
    /// Classe responsavel por implementar a IRepositorioUsuario.
    /// </summary>
    public class RepositorioUsuario : IRepositorioUsuario
    {
        #region Sql Tabela Usuario

        private static String QUERY_INSERT = "INSERT INTO Usuario (Nome,Login,Senha) VALUES (@Nome,@Login,@Senha)";
        private static String QUERY_UPDATE = "UPDATE Usuarios SET Nome = @Nome WHERE Id = @Id";
        private static String QUERY_UPDATE_SENHA = "UPDATE Usuario SET Senha = @Senha WHERE Id = @Id";
        private static String QUERY_DELETE = "DELETE FROM Usuario WHERE Id = @Id";
        private static String QUERY_SELECT_ID = "SELECT Id,Nome,Login,Senha FROM Usuario WHERE Id = @Id";
        private static String QUERY_SELECT_LOGIN_SENHA = "SELECT Id,Nome,Login,Senha FROM Usuario WHERE Login = @Login AND Senha = @Senha";
        private static String QUERY_SELECT_LOGIN = "SELECT Id,Nome,Login,Senha FROM UsuariO WHERE Login = @Login";
        private static String QUERY_SELECT_ALL = "SELECT Id,Nome,Login,Senha FROM Usuario";
        private static String QUERY_MAX_ID = "SELECT MAX(Id) Id FROM Usuario";

        #endregion

        #region Membros de IRepositorioUsuario

        /// <summary>
        /// Metodo responsavel por inserir um Usuario.
        /// </summary>
        /// <param name="usuario">Objeto do tipo Usuario a ser inserido</param>
        /// <returns>retorna o Usuario inserido.</returns>
        public Usuario Inserir(Usuario usuario)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();

            try
            {
                SqlCommand comando = new SqlCommand(QUERY_INSERT, conexao);
                comando.Parameters.AddWithValue("@Nome", usuario.Nome);
                comando.Parameters.AddWithValue("@Login", usuario.Login);
                comando.Parameters.AddWithValue("@Senha", usuario.Senha);
                conexao.Open();
                int regitrosAfetados = comando.ExecuteNonQuery();
                usuario.Id = this.ObterMaximoId();
            }
            catch (SqlException e)
            {
                throw new ErroBanco(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }
            return usuario;
        }

        /// <summary>
        /// Metodo responsavel por alterar um Usuario.
        /// </summary>
        /// <param name="usuario">Objeto do tipo Usuario a ser alterado</param>
        public void Alterar(Usuario usuario)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();

            try
            {
                SqlCommand comando = new SqlCommand(QUERY_UPDATE, conexao);
                comando.Parameters.AddWithValue("@Nome", usuario.Nome);
                comando.Parameters.AddWithValue("@Id", usuario.Id);
                conexao.Open();
                int regitrosAfetados = comando.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new ErroBanco(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }
        }

        /// <summary>
        /// Metodo responsavel por alterar a senha de um Usuario.
        /// </summary>
        /// <param name="id">Id do Usuario.</param>
        /// <param name="senha">Nova Senha.</param>
        public void Alterar(int id, string senha)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();

            try
            {
                SqlCommand comando = new SqlCommand(QUERY_UPDATE_SENHA, conexao);
                comando.Parameters.AddWithValue("@Senha", senha);
                comando.Parameters.AddWithValue("@Id", id);
                conexao.Open();
                int regitrosAfetados = comando.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new ErroBanco(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }
        }

        /// <summary>
        /// Metodo responsavel por remover um Usuario.
        /// </summary>
        /// <param name="id">Id do Usuario a ser removido.</param>
        public void Remover(int id)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();

            try
            {
                SqlCommand comando = new SqlCommand(QUERY_DELETE, conexao);
                comando.Parameters.AddWithValue("@Id", id);
                conexao.Open();
                int regitrosAfetados = comando.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new ErroBanco(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            } 
        }

        /// <summary>
        /// Metodo responsavel por consultar um Usuario.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um Usuario com o Id informado.</returns>
        public Usuario Consultar(int id)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            Usuario usuario = null;
            try
            {
                SqlCommand comando = new SqlCommand(QUERY_SELECT_ID, conexao);
                SqlDataReader resultado;
                comando.Parameters.AddWithValue("@Id", id);
                conexao.Open();

                resultado = comando.ExecuteReader();

                resultado.Read();
                if (resultado.HasRows)
                {
                    usuario = this.CriarUsuario(resultado);
                }

                resultado.Close();
            }

            catch (SqlException e)
            {
                throw new ErroBanco(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }

            return usuario;
        }

        /// <summary>
        /// Metodo responsavel por consultar um Usuario pelo seu Login e senha.
        /// </summary>
        /// <param name="login">Login a ser pesquisado.</param>
        /// <param name="senha">Senha a ser pesquisado.</param>
        /// <returns>Objeto do tipo Usuario.</returns>
        public Usuario Consultar(string login, string senha)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            Usuario usuario = null;
            try
            {
                SqlCommand comando = new SqlCommand(QUERY_SELECT_LOGIN_SENHA, conexao);
                SqlDataReader resultado;
                comando.Parameters.AddWithValue("@Login", login);
                comando.Parameters.AddWithValue("@Senha", senha);
                conexao.Open();

                resultado = comando.ExecuteReader();

                resultado.Read();
                if (resultado.HasRows)
                {
                    usuario = this.CriarUsuario(resultado);
                }

                resultado.Close();
            }

            catch (SqlException e)
            {
                throw new ErroBanco(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }

            return usuario;
        }

        /// <summary>
        /// Metodo responsavel por consultar um Usuario pelo seu Login.
        /// </summary>
        /// <param name="login">Login a ser pesquisado.</param>
        /// <returns>Objeto do tipo Usuario.</returns>
        public Usuario Consultar(string login)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            Usuario usuario = null;
            try
            {
                SqlCommand comando = new SqlCommand(QUERY_SELECT_LOGIN, conexao);
                SqlDataReader resultado;
                comando.Parameters.AddWithValue("@Login", login);
                conexao.Open();

                resultado = comando.ExecuteReader();

                resultado.Read();
                if (resultado.HasRows)
                {

                    usuario = this.CriarUsuario(resultado);
                }

                resultado.Close();
            }

            catch (SqlException e)
            {
                throw new ErroBanco(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }

            return usuario;
        }

        /// <summary>
        /// Metodo reponsavel por consultar todos os Usuarios.
        /// </summary>
        /// <returns>Lista com todo os Usuarios cadastrados.</returns>
        public List<Usuario> Consultar()
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                SqlCommand comando = new SqlCommand(QUERY_SELECT_ALL, conexao);
                SqlDataReader resultado;
                conexao.Open();

                resultado = comando.ExecuteReader();

                if (resultado.HasRows)
                {
                    while (resultado.Read())
                    {
                        usuarios.Add(this.CriarUsuario(resultado));
                    }
                }
                resultado.Close();
            }

            catch (SqlException e)
            {
                throw new ErroBanco(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }

            return usuarios;
        }

        /// <summary>
        /// Devolve o numero do maior Id inserido;
        /// </summary>
        /// <returns>valor do maior id</returns>
        private int ObterMaximoId()
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            int id = 0;
            try
            {
                SqlCommand comando = new SqlCommand(QUERY_MAX_ID, conexao);
                SqlDataReader resultado;
                conexao.Open();

                resultado = comando.ExecuteReader();
                resultado.Read();
                if (resultado.HasRows)
                {
                    if (resultado["Id"] != DBNull.Value)
                    {
                        id = Convert.ToInt32(resultado["Id"]);
                    }
                }
                resultado.Close();
            }

            catch (SqlException e)
            {
                throw new ErroBanco(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }

            return id;
        }

        #endregion

        /// <summary>
        /// Metodo para montar uma Usuario recebendo um SqlDataReader como parametro.
        /// </summary>
        /// <param name="resultado">SqlDataReader</param>
        /// <returns>Retorna uma Usuario.</returns>
        private Usuario CriarUsuario(SqlDataReader resultado)
        {
            Usuario usuario = new Usuario();
            if (resultado["Id"] != DBNull.Value)
            {
                usuario.Id = Convert.ToInt32(resultado["Id"]);
            }
            if (resultado["Nome"] != DBNull.Value)
            {
                usuario.Nome = Convert.ToString(resultado["Nome"]);
            }            
            if (resultado["Login"] != DBNull.Value)
            {
                usuario.Login = Convert.ToString(resultado["Login"]);
            }
            if (resultado["Senha"] != DBNull.Value)
            {
                usuario.Senha = Convert.ToString(resultado["Senha"]);
            }
            return usuario;
        }
    }
}
