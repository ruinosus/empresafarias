﻿using System;
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
    /// Classe responsavel por implementar a IRepositorioDependente.
    /// </summary>
    public class RepositorioDependente : IRepositorioDependente
    {
        #region Sql Tabela Dependente

        private static String QUERY_INSERT = "INSERT INTO Dependente (Nome,Religiao,DataNascimento,TitularId,Parentesco,PercentualCobertura,Status) VALUES (@Nome,@Religiao,@DataNascimento,@TitularId,@Parentesco,@PercentualCobertura,@Status)";
        private static String QUERY_UPDATE = "UPDATE Dependente SET Nome = @Nome,Religiao = @Religiao,DataNascimento = @DataNascimento,TitularId = @TitularId,Parentesco = @Parentesco,PercentualCobertura = @PercentualCobertura,Status = @Status WHERE Id = @Id";
        private static String QUERY_DELETE = "DELETE FROM Dependente WHERE Id = @Id";
        private static String QUERY_SELECT_ID = "SELECT Id,Nome,Religiao,DataNascimento,TitularId,Parentesco,PercentualCobertura,Status FROM Dependente WHERE Id = @Id";
        private static String QUERY_SELECT_TITULAR_ID = "SELECT Id,Nome,Religiao,DataNascimento,TitularId,Parentesco,PercentualCobertura,Status FROM Dependente WHERE TitularId = @TitularId";
        private static String QUERY_SELECT_ALL = "SELECT Id,Nome,Religiao,DataNascimento,TitularId,Parentesco,PercentualCobertura,Status FROM Dependente";
        private static String QUERY_MAX_ID = "SELECT MAX(Id) Id FROM Dependente";

        #endregion

        #region Membros de IRepositorioDependente
        /// <summary>
        /// Metodo responsavel por inserir um Dependente.
        /// </summary>
        /// <param name="dependente">Objeto do tipo Dependente a ser inserido</param>
        /// <returns>retorna o Dependente inserido.</returns>
        public Dependente Inserir(Dependente dependente)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();

            try
            {
                SqlCommand comando = new SqlCommand(QUERY_INSERT, conexao);
                comando.Parameters.AddWithValue("@DataNascimento", dependente.DataNascimento);
                comando.Parameters.AddWithValue("@Nome", dependente.Nome);
                comando.Parameters.AddWithValue("@Parentesco", dependente.Parentesco);
                comando.Parameters.AddWithValue("@Religiao", dependente.Religiao);
                comando.Parameters.AddWithValue("@Status", (int)dependente.Status);
                comando.Parameters.AddWithValue("@PercentualCobertura", dependente.PercentualCobertura);
                comando.Parameters.AddWithValue("@TitularId", dependente.TitularId);
                conexao.Open();
                int regitrosAfetados = comando.ExecuteNonQuery();
                dependente.Id = this.ObterMaximoId();
            }
            catch (SqlException e)
            {
                throw new ErroBanco(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }
            return dependente;
        }

        /// <summary>
        /// Metodo responsavel por alterar um Dependente.
        /// </summary>
        /// <param name="dependente">Objeto do tipo Dependente a ser alterado</param>
        public void Alterar(Dependente dependente)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();

            try
            {
                SqlCommand comando = new SqlCommand(QUERY_UPDATE, conexao);
                comando.Parameters.AddWithValue("@DataNascimento", dependente.DataNascimento);
                comando.Parameters.AddWithValue("@Nome", dependente.Nome);
                comando.Parameters.AddWithValue("@Parentesco", dependente.Parentesco);
                comando.Parameters.AddWithValue("@Religiao", dependente.Religiao);
                comando.Parameters.AddWithValue("@Status", (int)dependente.Status);
                comando.Parameters.AddWithValue("@PercentualCobertura", dependente.PercentualCobertura);
                comando.Parameters.AddWithValue("@TitularId", dependente.TitularId);
                comando.Parameters.AddWithValue("@Id", dependente.Id);
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
        /// Metodo responsavel por remover um Dependente.
        /// </summary>
        /// <param name="id">Id do Dependente a ser removido.</param>
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
        /// Metodo responsavel por consultar um Dependente.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um Dependente com o Id informado.</returns>
        public Dependente Consultar(int id)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            Dependente dependente = null;
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
                    dependente = this.CriarDependente(resultado);
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

            return dependente;
        }

        /// <summary>
        /// Metodo responsavel por consultar todos os Dependentes cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os Dependentes cadastrados.</returns>
        public List<Dependente> Consultar()
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            List<Dependente> dependentes = new List<Dependente>();
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
                        dependentes.Add(this.CriarDependente(resultado));
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

            return dependentes;
        }

        /// <summary>
        /// Metodo responsavel por consultar os Dependentes de um Titular.
        /// </summary>
        /// <param name="titular">Titular a ser utilizado como pesquisa.</param>
        /// <returns>retorna uma Lista com todos os Dependentes encontrados do Titular informado.</returns>
        public List<Dependente> Consultar(Titular titular)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            List<Dependente> dependentes = new List<Dependente>();
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
                        dependentes.Add(this.CriarDependente(resultado));
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

            return dependentes;
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
        /// Metodo para montar um Dependente recebendo um SqlDataReader como parametro.
        /// </summary>
        /// <param name="resultado">SqlDataReader</param>
        /// <returns>Retorna um Dependente</returns>
        private Dependente CriarDependente(SqlDataReader resultado)
        {
            Dependente dependente = new Dependente();

            if (resultado["Id"] != DBNull.Value)
            {
                dependente.Id = Convert.ToInt32(resultado["Id"]);
            }
            if (resultado["DataNascimento"] != DBNull.Value)
            {
                dependente.DataNascimento = Convert.ToDateTime(resultado["DataNascimento"]);
            }
            if (resultado["Nome"] != DBNull.Value)
            {
                dependente.Nome = Convert.ToString(resultado["Nome"]);
            }
            if (resultado["Status"] != DBNull.Value)
            {
                dependente.Status =(StatusControle)Convert.ToInt32(resultado["Status"]);
            }
            if (resultado["Parentesco"] != DBNull.Value)
            {
                dependente.Parentesco = Convert.ToString(resultado["Parentesco"]);
            }
            if (resultado["PercentualCobertura"] != DBNull.Value)
            {
                dependente.PercentualCobertura = Convert.ToInt32(resultado["PercentualCobertura"]);
            }
            if (resultado["Religiao"] != DBNull.Value)
            {
                dependente.Religiao = Convert.ToString(resultado["Religiao"]);
            }
            if (resultado["TitularId"] != DBNull.Value)
            {
                dependente.TitularId = Convert.ToInt32(resultado["TitularId"]);
            }


            return dependente;
        }
    }
}
