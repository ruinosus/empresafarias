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
    /// Classe responsavel por implementar a IRepositorioHistoricoParcela.
    /// </summary>
    public class RepositorioHistoricoParcela : IRepositorioHistoricoParcela
    {
        #region Sql Tabela HistoricoParcela

        private static String QUERY_INSERT_1 = "INSERT INTO HistoricoParcela (DataPagamento,DataVencimento,Valor,NumeroParcela,Status,ContratoId,ParcelaId,DataAltecarao,UsuarioId,Descricao) VALUES (@DataPagamento,@DataVencimento,@Valor,@NumeroParcela,@Status,@ContratoId,@ParcelaId,@DataAltecarao,@UsuarioId,@Descricao)";
        private static String QUERY_INSERT_2 = "INSERT INTO HistoricoParcela (DataVencimento,Valor,NumeroParcela,Status,ContratoId,ParcelaId,DataAltecarao,UsuarioId,Descricao) VALUES (@DataVencimento,@Valor,@NumeroParcela,@Status,@ContratoId,@ParcelaId,@DataAltecarao,@UsuarioId,@Descricao)";
        private static String QUERY_SELECT_ID = "SELECT Id,DataPagamento,DataVencimento,Valor,NumeroParcela,Status,ContratoId,ParcelaId,DataAltecarao,UsuarioId,Descricao FROM HistoricoParcela WHERE Id = @Id";
        private static String QUERY_SELECT_ALL = "SELECT Id,DataPagamento,DataVencimento,Valor,NumeroParcela,Status,ContratoId,ParcelaId,DataAltecarao,UsuarioId,Descricao FROM HistoricoParcela";
        private static String QUERY_MAX_ID = "SELECT MAX(Id) Id FROM HistoricoParcela";

        #endregion

        #region Membros de IRepositorioHistoricoParcela

        /// <summary>
        /// Metodo responsavel por inserir um Historico da Parcela.
        /// </summary>
        /// <param name="historicoParcela">Objeto do tipo HistoricoParcela a ser inserido</param>
        /// <param name="ContratoId">Id do Contrato do Historico da Parcela.</param>
        /// <returns>retorna o HistoricoParcela inserido.</returns>
        public HistoricoParcela Inserir(HistoricoParcela historicoParcela, int ContratoId)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();

            try
            {
                SqlCommand comando;
                if (historicoParcela.DataPagamento != null)
                {
                    comando = new SqlCommand(QUERY_INSERT_1, conexao);
                    comando.Parameters.AddWithValue("@DataPagamento", historicoParcela.DataPagamento);
                }
                else
                {
                    comando = new SqlCommand(QUERY_INSERT_2, conexao);
                }
                comando.Parameters.AddWithValue("@DataVencimento", historicoParcela.DataVencimento);
                comando.Parameters.AddWithValue("@Valor", historicoParcela.Valor);
                comando.Parameters.AddWithValue("@NumeroParcela", historicoParcela.NumeroParcela);
                comando.Parameters.AddWithValue("@Status", (int)historicoParcela.Status);
                comando.Parameters.AddWithValue("@ContratoId", ContratoId);
                conexao.Open();
                int regitrosAfetados = comando.ExecuteNonQuery();
                historicoParcela.Id = this.ObterMaximoId();
            }
            catch (SqlException e)
            {
                throw new ErroBanco(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }
            return historicoParcela;
        }
        
        /// <summary>
        /// Metodo responsavel por consultar uma Parcela.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um HistoricoParcela com o Id informado.</returns>
        public HistoricoParcela Consultar(int id)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            HistoricoParcela historicoParcela = null;
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
                    historicoParcela = this.CriarHistoricoParcela(resultado);
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

            return historicoParcela;
        }

        /// <summary>
        /// Metodo responsavel por consultar todas as Parcelas cadastradas.
        /// </summary>
        /// <returns>retorna uma Lista com todos os HistoricosParcelas cadastradas.</returns>
        public List<HistoricoParcela> Consultar()
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            List<HistoricoParcela> historicosParcela = new List<HistoricoParcela>();
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
                        historicosParcela.Add(this.CriarHistoricoParcela(resultado));
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

            return historicosParcela;
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
        /// Metodo para montar uma Parcela recebendo um SqlDataReader como parametro.
        /// </summary>
        /// <param name="resultado">SqlDataReader</param>
        /// <returns>Retorna um HistoricoParcela</returns>
        private HistoricoParcela CriarHistoricoParcela(SqlDataReader resultado)
        {
            HistoricoParcela historicoParcela = new HistoricoParcela();

            if (resultado["Id"] != DBNull.Value)
            {
                historicoParcela.Id = Convert.ToInt32(resultado["Id"]);
            }
            if (resultado["DataPagamento"] != DBNull.Value)
            {
                historicoParcela.DataPagamento = Convert.ToDateTime(resultado["DataPagamento"]);
            }
            if (resultado["DataVencimento"] != DBNull.Value)
            {
                historicoParcela.DataVencimento = Convert.ToDateTime(resultado["DataVencimento"]);
            }
            if (resultado["Valor"] != DBNull.Value)
            {
                historicoParcela.Valor = Convert.ToDecimal(resultado["Valor"]);
            }
            if (resultado["NumeroParcela"] != DBNull.Value)
            {
                historicoParcela.NumeroParcela = Convert.ToInt32(resultado["NumeroParcela"]);
            }
            if (resultado["Status"] != DBNull.Value)
            {
                historicoParcela.Status = (StatusParcela)Convert.ToInt32(resultado["Status"]);
            }
            if (resultado["Status"] != DBNull.Value)
            {
                historicoParcela.Status = (StatusParcela)Convert.ToInt32(resultado["Status"]);
            }

            if (resultado["ParcelaId"] != DBNull.Value)
            {
                historicoParcela.Parcela.Id = Convert.ToInt32(resultado["ParcelaId"]);
            }
            if (resultado["DataAlteracao"] != DBNull.Value)
            {
                historicoParcela.DataAlteracao = Convert.ToDateTime(resultado["DataAlteracao"]);
            }
            if (resultado["UsuarioId"] != DBNull.Value)
            {
                historicoParcela.Usuario.Id = Convert.ToInt32(resultado["UsuarioId"]);
            }
            if (resultado["Descricao"] != DBNull.Value)
            {
                historicoParcela.Descricao = Convert.ToString(resultado["Descricao"]);
            }


            return historicoParcela;
        }
    }
}
