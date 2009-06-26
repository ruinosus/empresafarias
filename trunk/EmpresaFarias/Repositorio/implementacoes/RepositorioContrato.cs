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
    /// Classe responsavel por implementar a IRepositorioContrato.
    /// </summary>
    public class RepositorioContrato : IRepositorioContrato
    {
        #region Sql Tabela Contrato

        private static String QUERY_INSERT = "INSERT INTO Contrato (Id,DataInicio,Status,TitularId,PlanoId) VALUES (@Id,@DataInicio,@Status,@TitularId,@PlanoId)";
        private static String QUERY_UPDATE = "UPDATE Contrato SET DataInicio = @DataInicio,Status = @Status,TitularId = @TitularId,PlanoId=@PlanoId WHERE Id = @Id";
        private static String QUERY_DELETE = "DELETE FROM Contrato WHERE Id = @Id";
        private static String QUERY_SELECT_ID = "SELECT Id,DataInicio,Status,TitularId,PlanoId FROM Contrato WHERE Id = @Id";
        private static String QUERY_SELECT_TITULAR_ID = "SELECT Id,DataInicio,Status,TitularId,PlanoId FROM Contrato WHERE TitularId = @TitularId";
        private static String QUERY_SELECT_ALL = "SELECT Id,DataInicio,Status,TitularId,PlanoId FROM Contrato";

        #endregion

        #region Membros de IRepositorioContrato
        /// <summary>
        /// Metodo responsavel por inserir um Contrato.
        /// </summary>
        /// <param name="contrato">Objeto do tipo Contrato a ser inserido</param>
        /// <param name="TitularId">Id do Titular do Contrato.</param>
        public void Inserir(Contrato contrato, int TitularId)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();

            try
            {
                SqlCommand comando = new SqlCommand(QUERY_INSERT, conexao);
                comando.Parameters.AddWithValue("@Id", contrato.Id);
                comando.Parameters.AddWithValue("@DataInicio", contrato.DataInicio);
                comando.Parameters.AddWithValue("@PlanoId", contrato.Plano.Id);
                comando.Parameters.AddWithValue("@Status", contrato.Status);
                comando.Parameters.AddWithValue("@TitularId", TitularId);
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
        /// Metodo responsavel por alterar um Contrato.
        /// </summary>
        /// <param name="contrato">Objeto do tipo Contrato a ser alterado</param>
        /// <param name="TitularId">Id do Titular do Contrato.</param>
        public void Alterar(Contrato contrato, int TitularId)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();

            try
            {
                SqlCommand comando = new SqlCommand(QUERY_UPDATE, conexao);
                comando.Parameters.AddWithValue("@Id", contrato.Id);
                comando.Parameters.AddWithValue("@DataInicio", contrato.DataInicio);
                comando.Parameters.AddWithValue("@PlanoId", contrato.Plano.Id);
                comando.Parameters.AddWithValue("@Status", contrato.Status);
                comando.Parameters.AddWithValue("@TitularId", TitularId);
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
        /// Metodo responsavel por remover um Contrato.
        /// </summary>
        /// <param name="id">Id do Contrato a ser removido.</param>
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
        /// Metodo responsavel por consultar um Contrato.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um Contrato com o Id informado.</returns>
        public Contrato Consultar(int id)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            Contrato contrato = null;
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
                    contrato = this.CriarContrato(resultado);
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

            return contrato;
        }
        /// <summary>
        /// Metodo responsavel por consultar todos os Contratos cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os Contratos cadastrados.</returns>
        public List<Contrato> Consultar()
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            List<Contrato> contratos = new List<Contrato>();
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
                        contratos.Add(this.CriarContrato(resultado));
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

            return contratos;
        }
        /// <summary>
        /// Metodo responsavel por consultar os Contratos de um Titular.
        /// </summary>
        /// <param name="titular">Titular a ser utilizado como pesquisa.</param>
        /// <returns>retorna uma Lista com todas os Contratos encontrados do Titular informado.</returns>
        public List<Contrato> Consultar(Titular titular)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            List<Contrato> contratos = new List<Contrato>();
            try
            {
                SqlCommand comando = new SqlCommand(QUERY_SELECT_TITULAR_ID, conexao);
                comando.Parameters.AddWithValue("@TitularId", titular.Id);
                SqlDataReader resultado;
                conexao.Open();

                resultado = comando.ExecuteReader();

                if (resultado.HasRows)
                {
                    while (resultado.Read())
                    {
                        contratos.Add(this.CriarContrato(resultado));
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

            return contratos;
        }

        #endregion

        /// <summary>
        /// Metodo para montar um Contrato recebendo um SqlDataReader como parametro.
        /// </summary>
        /// <param name="resultado">SqlDataReader</param>
        /// <returns>Retorna um Contrato</returns>
        private Contrato CriarContrato(SqlDataReader resultado)
        {
            Contrato contrato = new Contrato();

            if (resultado["Id"] != DBNull.Value)
            {
                contrato.Id = Convert.ToInt32(resultado["Id"]);
            }
            if (resultado["DataInicio"] != DBNull.Value)
            {
                contrato.DataInicio = Convert.ToDateTime(resultado["DataInicio"]);
            }
            if (resultado["PlanoId"] != DBNull.Value)
            {
                contrato.Plano.Id = Convert.ToInt32(resultado["PlanoId"]);
            }
            if (resultado["Status"] != DBNull.Value)
            {
                contrato.Status = Convert.ToString(resultado["Status"]);
            }           
            return contrato;
        }
    }
}
