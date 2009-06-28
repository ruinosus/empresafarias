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
    /// Classe responsavel por implementar a IRepositorioHistoricoDependente.
    /// </summary>
    public class RepositorioHistoricoDependente : IRepositorioHistoricoDependente
    {
        #region Sql Tabela HistoricoDependente

        private static String QUERY_INSERT = "INSERT INTO HistoricoDependente (Nome,Religiao,DataNascimento,TitularId,Parentesco,PercentualCobertura,Status,DependenteId,DataAlteracao,UsuarioId,Descricao) VALUES (@Nome,@Religiao,@DataNascimento,@TitularId,@Parentesco,@PercentualCobertura,@Status,@DependenteId,@DataAlteracao,@UsuarioId,@Descricao)";
        private static String QUERY_SELECT_ID = "SELECT Id,Nome,Religiao,DataNascimento,TitularId,Parentesco,PercentualCobertura,Status,DependenteId,DataAlteracao,UsuarioId,Descricao FROM HistoricoDependente WHERE Id = @Id";
        private static String QUERY_SELECT_ALL = "SELECT Id,Nome,Religiao,DataNascimento,TitularId,Parentesco,PercentualCobertura,Status,DependenteId,DataAlteracao,UsuarioId,Descricao FROM HistoricoDependente";
        private static String QUERY_MAX_ID = "SELECT MAX(Id) Id FROM HistoricoDependente";

        #endregion

        #region Membros de IRepositorioHistoricoDependente

        /// <summary>
        /// Metodo responsavel por inserir um HistoricoDependente.
        /// </summary>
        /// <param name="historicoDependente">Objeto do tipo HistoricoDependente a ser inserido</param>
        /// <param name="TitularId">Id do Titular do HistoricoDependente.</param>
        /// <returns>retorna o HistoricoDependente inserido.</returns>
        public HistoricoDependente Inserir(HistoricoDependente historicoDependente, int TitularId)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();

            try
            {
                SqlCommand comando = new SqlCommand(QUERY_INSERT, conexao);
                comando.Parameters.AddWithValue("@DataNascimento", historicoDependente.DataNascimento);
                comando.Parameters.AddWithValue("@Nome", historicoDependente.Nome);
                comando.Parameters.AddWithValue("@Parentesco", historicoDependente.Parentesco);
                comando.Parameters.AddWithValue("@Religiao", historicoDependente.Religiao);
                comando.Parameters.AddWithValue("@Status", (int)historicoDependente.Status);
                comando.Parameters.AddWithValue("@PercentualCobertura", historicoDependente.PercentualCobertura);
                comando.Parameters.AddWithValue("@TitularId", TitularId);
                comando.Parameters.AddWithValue("@DependenteId", historicoDependente.Dependente.Id);
                comando.Parameters.AddWithValue("@DataAlteracao", historicoDependente.DataAlteracao);
                comando.Parameters.AddWithValue("@UsuarioId", historicoDependente.Usuario.Id);
                comando.Parameters.AddWithValue("@Descricao", historicoDependente.Descricao);
                conexao.Open();
                int regitrosAfetados = comando.ExecuteNonQuery();
                historicoDependente.Id = this.ObterMaximoId();
            }
            catch (SqlException e)
            {
                throw new ErroBanco(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }
            return historicoDependente;
        }

        /// <summary>
        /// Metodo responsavel por consultar um HistoricoDependente.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um HistoricoDependente com o Id informado.</returns>
        public HistoricoDependente Consultar(int id)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            HistoricoDependente historicoDependente = null;
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
                    historicoDependente = this.CriarHistoricoDependente(resultado);
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

            return historicoDependente;
        }

        /// <summary>
        /// Metodo responsavel por consultar todos os HistoricosDependente cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os HistoricosDependente cadastrados.</returns>
        public List<HistoricoDependente> Consultar()
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            List<HistoricoDependente> historicos = new List<HistoricoDependente>();
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
                        historicos.Add(this.CriarHistoricoDependente(resultado));
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

            return historicos;
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
        /// Metodo para montar um HistoricoDependente recebendo um SqlDataReader como parametro.
        /// </summary>
        /// <param name="resultado">SqlDataReader</param>
        /// <returns>Retorna um HistoricoDependente</returns>
        private HistoricoDependente CriarHistoricoDependente(SqlDataReader resultado)
        {
            HistoricoDependente historicoDependente = new HistoricoDependente();

            if (resultado["Id"] != DBNull.Value)
            {
                historicoDependente.Id = Convert.ToInt32(resultado["Id"]);
            }
            if (resultado["DataNascimento"] != DBNull.Value)
            {
                historicoDependente.DataNascimento = Convert.ToDateTime(resultado["DataNascimento"]);
            }
            if (resultado["Nome"] != DBNull.Value)
            {
                historicoDependente.Nome = Convert.ToString(resultado["Nome"]);
            }
            if (resultado["Status"] != DBNull.Value)
            {
                historicoDependente.Status = (StatusDependente)Convert.ToInt32(resultado["Status"]);
            }
            if (resultado["Parentesco"] != DBNull.Value)
            {
                historicoDependente.Parentesco = Convert.ToString(resultado["Parentesco"]);
            }
            if (resultado["PercentualCobertura"] != DBNull.Value)
            {
                historicoDependente.PercentualCobertura = Convert.ToInt32(resultado["PercentualCobertura"]);
            }
            if (resultado["Religiao"] != DBNull.Value)
            {
                historicoDependente.Religiao = Convert.ToString(resultado["Religiao"]);
            }

            if (resultado["DependenteId"] != DBNull.Value)
            {
                historicoDependente.Dependente.Id = Convert.ToInt32(resultado["DependenteId"]);
            }
            if (resultado["DataAlteracao"] != DBNull.Value)
            {
                historicoDependente.DataAlteracao = Convert.ToDateTime(resultado["DataAlteracao"]);
            }
            if (resultado["UsuarioId"] != DBNull.Value)
            {
                historicoDependente.Usuario.Id = Convert.ToInt32(resultado["UsuarioId"]);
            }
            if (resultado["Descricao"] != DBNull.Value)
            {
                historicoDependente.Descricao = Convert.ToString(resultado["Descricao"]);
            }

            return historicoDependente;
        }

    }
}
