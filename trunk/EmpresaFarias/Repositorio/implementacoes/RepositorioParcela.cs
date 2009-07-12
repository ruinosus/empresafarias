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
    /// Classe responsavel por implementar a IRepositorioParcela.
    /// </summary>
    public class RepositorioParcela : IRepositorioParcela
    {
        #region Sql Tabela Parcela

        private static String QUERY_INSERT_1 = "INSERT INTO Parcela (DataPagamento,DataVencimento,Valor,NumeroParcela,Status,ContratoId) VALUES (@DataPagamento,@DataVencimento,@Valor,@NumeroParcela,@Status,@ContratoId)";
        private static String QUERY_INSERT_2 = "INSERT INTO Parcela (DataVencimento,Valor,NumeroParcela,Status,ContratoId) VALUES (@DataVencimento,@Valor,@NumeroParcela,@Status,@ContratoId)";
        private static String QUERY_UPDATE = "UPDATE Parcela SET DataPagamento = @DataPagamento,DataVencimento = @DataVencimento,Valor = @Valor,NumeroParcela = @NumeroParcela,Status = @Status,ContratoId = @ContratoId WHERE Id = @Id";
        private static String QUERY_DELETE = "DELETE FROM Parcela WHERE Id = @Id";
        private static String QUERY_SELECT_ID = "SELECT Id,DataPagamento,DataVencimento,Valor,NumeroParcela,Status,ContratoId FROM Parcela WHERE Id = @Id";
        private static String QUERY_SELECT_CONTRATO_ID = "SELECT Id,DataPagamento,DataVencimento,Valor,NumeroParcela,Status,ContratoId FROM Parcela WHERE ContratoId = @ContratoId";
        private static String QUERY_SELECT_ALL = "SELECT Id,DataPagamento,DataVencimento,Valor,NumeroParcela,Status,ContratoId FROM Parcela";
        private static String QUERY_MAX_ID = "SELECT MAX(Id) Id FROM Parcela";

        #endregion

        #region Membros de IRepositorioParcela

        /// <summary>
        /// Metodo responsavel por inserir uma Parcela.
        /// </summary>
        /// <param name="parcela">Objeto do tipo Parcela a ser inserido</param>
        /// <returns>retorna o Parcela inserido.</returns>
        public Parcela Inserir(Parcela parcela)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();

            try
            {
                SqlCommand comando;
                if(parcela.DataPagamento != null)
                {
                    comando = new SqlCommand(QUERY_INSERT_1, conexao);
                    comando.Parameters.AddWithValue("@DataPagamento", parcela.DataPagamento);
                }else
                {
                    comando = new SqlCommand(QUERY_INSERT_2, conexao);
                }
                comando.Parameters.AddWithValue("@DataVencimento", parcela.DataVencimento);
                comando.Parameters.AddWithValue("@Valor", parcela.Valor);
                comando.Parameters.AddWithValue("@NumeroParcela", parcela.NumeroParcela);
                comando.Parameters.AddWithValue("@Status",(int) parcela.Status);
                comando.Parameters.AddWithValue("@ContratoId", parcela.ContratoId);
                conexao.Open();
                int regitrosAfetados = comando.ExecuteNonQuery();
                parcela.Id = this.ObterMaximoId();
            }
            catch (SqlException e)
            {
                throw new ErroBanco(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }
            return parcela;
        }

        /// <summary>
        /// Metodo responsavel por alterar uma Parcela.
        /// </summary>
        /// <param name="plano">Objeto do tipo Parcela a ser alterado</param>
        public void Alterar(Parcela parcela)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();

            try
            {
                SqlCommand comando  = new SqlCommand(QUERY_UPDATE, conexao);
                comando.Parameters.AddWithValue("@DataPagamento", parcela.DataPagamento);
                comando.Parameters.AddWithValue("@DataVencimento", parcela.DataVencimento);
                comando.Parameters.AddWithValue("@Valor", parcela.Valor);
                comando.Parameters.AddWithValue("@NumeroParcela", parcela.NumeroParcela);
                comando.Parameters.AddWithValue("@Status", (int)parcela.Status);
                comando.Parameters.AddWithValue("@ContratoId", parcela.Id);
                comando.Parameters.AddWithValue("@Id", parcela.ContratoId);
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
        /// Metodo responsavel por remover uma Parcela.
        /// </summary>
        /// <param name="id">Id do Parcela a ser removida.</param>
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
        /// Metodo responsavel por consultar uma Parcela.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna uma Parcela com o Id informado.</returns>
        public Parcela Consultar(int id)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            Parcela parcela = null;
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
                    parcela = this.CriarParcela(resultado);
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

            return parcela;
        }

        /// <summary>
        /// Metodo responsavel por consultar todas as Parcelas cadastradas.
        /// </summary>
        /// <returns>retorna uma Lista com todas as Parcelas cadastradas.</returns>
        public List<Parcela> Consultar()
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            List<Parcela> parcelas = new List<Parcela>();
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
                        parcelas.Add(this.CriarParcela(resultado));
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

            return parcelas;
        }

        /// <summary>
        /// Metodo responsavel por consultar as Parcelas de um Contrato.
        /// </summary>
        /// <returns>retorna uma Lista com todas as Parcelas encontradas do Contrato informado.</returns>
        public List<Parcela> Consultar(Contrato contrato)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            List<Parcela> parcelas = new List<Parcela>();
            try
            {
                SqlCommand comando = new SqlCommand(QUERY_SELECT_CONTRATO_ID, conexao);
                comando.Parameters.AddWithValue("@ContratoId",contrato.Id);
                SqlDataReader resultado;
                conexao.Open();

                resultado = comando.ExecuteReader();

                if (resultado.HasRows)
                {
                    while (resultado.Read())
                    {
                        parcelas.Add(this.CriarParcela(resultado));
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

            return parcelas;
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
        /// <returns>Retorna uma Parcela</returns>
        private Parcela CriarParcela(SqlDataReader resultado)
        {
            Parcela parcela = new Parcela();

            if (resultado["Id"] != DBNull.Value)
            {
                parcela.Id = Convert.ToInt32(resultado["Id"]);
            }
            if (resultado["DataPagamento"] != DBNull.Value)
            {
                parcela.DataPagamento = Convert.ToDateTime(resultado["DataPagamento"]);
            }
            if (resultado["DataVencimento"] != DBNull.Value)
            {
                parcela.DataVencimento = Convert.ToDateTime(resultado["DataVencimento"]);
            }
            if (resultado["Valor"] != DBNull.Value)
            {
                parcela.Valor = Convert.ToDecimal(resultado["Valor"]);
            }
            if (resultado["NumeroParcela"] != DBNull.Value)
            {
                parcela.NumeroParcela = Convert.ToInt32(resultado["NumeroParcela"]);
            }
            if (resultado["Status"] != DBNull.Value)
            {
                parcela.Status = (StatusParcela)Convert.ToInt32(resultado["Status"]);
            }
            if (resultado["ContratoId"] != DBNull.Value)
            {
                parcela.ContratoId = Convert.ToInt32(resultado["ContratoId"]);
            }
            return parcela;
        }
    }
}
