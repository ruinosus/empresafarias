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
    /// Classe responsavel por implementar a IRepositorioPerfil.
    /// </summary>
    public class RepositorioPerfil : IRepositorioPerfil
    {
        #region Sql Tabela UsuarioPerfil

        private static String QUERY_INSERT = "INSERT INTO UsuarioPerfil (UsuarioId,PerfilId) VALUES (@UsuarioId,@PerfilId)";
        private static String QUERY_DELETE = "DELETE FROM UsuarioPerfil WHERE UsuarioId = @UsuarioId AND PerfilId = @PerfilId";
        private static String QUERY_SELECT_USUARIO = "SELECT PerfilId FROM UsuarioPerfil WHERE UsuarioId = @UsuarioId";
        private static String QUERY_DELETE_USUARIO = "DELETE FROM UsuarioPerfil WHERE UsuarioId = @UsuarioId";
        
        #endregion

        #region Sql Tabela Perfil

        private static String QUERY_SELECT_ID = "SELECT Id,Descricao FROM Perfil WHERE Id = @Id";
        private static String QUERY_SELECT_ALL = "SELECT Id,Descricao FROM Perfil";

        #endregion

        #region Sql Tabela Tag

        private static String QUERY_SELECT_TAG = "SELECT TagId FROM Tag WHERE PerfilID = @PerfilID";
        
        #endregion

        #region Membros de IRepositorioPerfil

        /// <summary>
        /// Metodo responsavel por inserir um Perfil de um Usuario.
        /// </summary>
        /// <param name="UsuarioId">Id do Usuario.</param>
        /// <param name="PerfilId"> Id do Perfil.</param>
        public void Inserir(int UsuarioId, int PerfilId)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();

            try
            {
                SqlCommand comando = new SqlCommand(QUERY_INSERT, conexao);
                comando.Parameters.AddWithValue("@UsuarioID", UsuarioId);
                comando.Parameters.AddWithValue("@PerfilID", PerfilId);
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
        /// Metodo responsavel por remover um Perfil de um Usuario.
        /// </summary>
        /// <param name="UsuarioId">Id do Usuario.</param>
        /// <param name="PerfilId"> Id do Perfil.</param>
        public void Remover(int UsuarioId, int PerfilId)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();

            try
            {
                SqlCommand comando = new SqlCommand(QUERY_DELETE, conexao);
                comando.Parameters.AddWithValue("@UsuarioID", UsuarioId);
                comando.Parameters.AddWithValue("@PerfilID", PerfilId);
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
        /// Metodo responsavel por remover um Perfil de um Usuario.
        /// </summary>
        /// <param name="usuario">Usuario.</param>
        public void Remover(Usuario usuario)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();

            try
            {
                SqlCommand comando = new SqlCommand(QUERY_DELETE_USUARIO, conexao);
                comando.Parameters.AddWithValue("@UsuarioID", usuario.Id);
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
        /// Metodo responsavel por consultar um Perfil.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um Perfil com o Id informado.</returns>
        public Perfil Consultar(int id)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            Perfil perfil = null;
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
                    perfil = this.CriarPerfil(resultado);
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

            return perfil;
        }

        /// <summary>
        /// Metodo responsavel por consultar todos os Perfis cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os Perfis cadastrados.</returns>
        public List<Perfil> Consultar()
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            List<Perfil> perfis = new List<Perfil>();
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
                        perfis.Add(this.CriarPerfil(resultado));
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

            return perfis;
        }

        /// <summary>
        /// Metodo responsavel por consultar todos os Perfis cadastrados.
        /// </summary>
        /// <param name="usuario">Usuario para pesquisa.</param>
        /// <returns>retorna uma Lista com todos os Perfis cadastrados do Usuario.</returns>
        public List<Perfil> Consultar(Usuario usuario)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            List<Perfil> perfis = new List<Perfil>();
            try
            {
                SqlCommand comando = new SqlCommand(QUERY_SELECT_USUARIO, conexao);
                comando.Parameters.AddWithValue("@UsuarioId", usuario.Id);
                SqlDataReader resultado;
                conexao.Open();

                resultado = comando.ExecuteReader();

                if (resultado.HasRows)
                {
                    while (resultado.Read())
                    {
                        if (resultado["PerfilId"] != DBNull.Value)
                        {
                            int id = Convert.ToInt32(resultado["PerfilId"]);
                            //Perfil p = new Perfil();
                            //p.Id = id;
                            //perfis.Add(p);
                            perfis.Add(this.Consultar(id));
                        }                       
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

            return perfis;
        }

        #endregion

        /// <summary>
        /// Metodo usado para Criar todas as Tags de um Perfil.
        /// </summary>
        /// <param name="PerfilId">Id do Perfil.</param>
        /// <returns>Retorna uma Lista com as Tags encontradas.</returns>
        private List<int> CriarTag(int PerfilId)
        {
            
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            List<int> tags = new List<int>();
            try
            {
                SqlCommand comando = new SqlCommand(QUERY_SELECT_TAG, conexao);
                comando.Parameters.AddWithValue("@PerfilId", PerfilId);
                SqlDataReader resultado;
                conexao.Open();

                resultado = comando.ExecuteReader();

                if (resultado.HasRows)
                {
                    while (resultado.Read())
                    {
                        if (resultado["TagId"] != DBNull.Value)
                        {
                            tags.Add(Convert.ToInt32(resultado["TagId"]));
                        }                        
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

            return tags;
        }

        /// <summary>
        /// Metodo para montar um Perfil recebendo um SqlDataReader como parametro.
        /// </summary>
        /// <param name="resultado">SqlDataReader</param>
        /// <returns>Retorna um Perfil.</returns>
        private Perfil CriarPerfil(SqlDataReader resultado)
        {
            Perfil perfil = new Perfil();
            if (resultado["Id"] != DBNull.Value)
            {
                perfil.Id = Convert.ToInt32(resultado["Id"]);
            }
            if (resultado["Descricao"] != DBNull.Value)
            {
                perfil.Descricao = Convert.ToString(resultado["Descricao"]);
            }

            perfil.Tags = this.CriarTag(perfil.Id);
            
            return perfil;
        }

    }
}
