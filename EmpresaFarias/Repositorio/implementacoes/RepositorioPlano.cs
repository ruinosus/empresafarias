using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.interfaces;
using ClassesBasicas;
using System.Data.SqlClient;
using Excecoes;

namespace Repositorio.implementacoes
{
    /// <summary>
    /// Classe responsavel por implementar a IRepositorioPlano.
    /// </summary>
    public class RepositorioPlano : IRepositorioPlano
    {
        #region Sql Tabela Plano
        
        private static String QUERY_INSERT = "INSERT INTO Plano (Nome,Descricao,ValorPadrao) VALUES (@Nome,@Descricao,@ValorPadrao)";
        private static String QUERY_UPDATE = "UPDATE Plano SET Nome= @Nome,Descricao = @Descricao,ValorPadrao = @ValorPardao WHERE Id = @Id";
        private static String QUERY_DELETE = "DELETE FROM Plano WHERE Id = @Id";
        private static String QUERY_SELECT_ID = "SELECT Id,Nome,Descricao,ValorPadrao FROM Plano WHERE Id = @Id";
        private static String QUERY_SELECT_ALL = "SELECT Id,Nome,Descricao,ValorPadrao FROM Plano";
        
        #endregion

        #region Membros de IRepositorioPlano
        /// <summary>
        /// Metodo responsavel por inserir um Plano.
        /// </summary>
        /// <param name="plano">Objeto do tipo Plano a ser inserido</param>
        public void Inserir(Plano plano)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();

            try
            {
                SqlCommand comando = new SqlCommand(QUERY_INSERT, conexao);
                comando.Parameters.AddWithValue("@Nome", plano.Nome);
                comando.Parameters.AddWithValue("@Descricao", plano.Descricao);
                comando.Parameters.AddWithValue("@ValorPadrao", plano.ValorPadrao);
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
        /// Metodo responsavel por alterar um Plano.
        /// </summary>
        /// <param name="plano">Objeto do tipo Plano a ser alterado</param>
        public void Alterar(Plano plano)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();

            try
            {
                SqlCommand comando = new SqlCommand(QUERY_UPDATE, conexao);
                comando.Parameters.AddWithValue("@Nome", plano.Nome);
                comando.Parameters.AddWithValue("@Descricao", plano.Descricao);
                comando.Parameters.AddWithValue("@ValorPadrao", plano.ValorPadrao);
                comando.Parameters.AddWithValue("@Id", plano.Id);
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
        /// Metodo responsavel por remover um Plano.
        /// </summary>
        /// <param name="id">Id do Plano a ser removido.</param>
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
        /// Metodo responsavel por consultar um Plano.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um Plano com o Id informado.</returns>
        public Plano Consultar(int id)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            Plano plano = null;
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
                    plano = this.CriarPlano(resultado);
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

            return plano;
        }
        /// <summary>
        /// Metodo responsavel por consultar todos os Planos cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os Planos cadastrador.</returns>
        public List<Plano> Consultar()
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            List<Plano> planos = new List<Plano>();
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
                        planos.Add(this.CriarPlano(resultado));
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

            return planos;
        }

        #endregion

        /// <summary>
        /// Metodo para montar um Plano recebendo um SqlDataReader como parametro.
        /// </summary>
        /// <param name="resultado">SqlDataReader</param>
        /// <returns>Retorna um Plano</returns>
        private Plano CriarPlano(SqlDataReader resultado)
        {
            Plano plano = new Plano();

            if (resultado["Id"] != DBNull.Value)
            {
                plano.Id = Convert.ToInt32(resultado["Id"]);
            }
            if (resultado["Nome"] != DBNull.Value)
            {
                plano.Nome = Convert.ToString(resultado["Nome"]);
            }
            if (resultado["Descricao"] != DBNull.Value)
            {
                plano.Descricao = Convert.ToString(resultado["Descricao"]);
            }
            if (resultado["ValorPadrao"] != DBNull.Value)
            {
                plano.ValorPadrao = Convert.ToDecimal(resultado["ValorPadrao"]);
            }
            return plano;
        }
    }
}

