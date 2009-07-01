using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Repositorio
{   /// <summary>
    /// Classe Reponsavel por Obter uma Conexao com o Banco de Dados.
    /// </summary>
    public class UtilBD
    {
        /// <summary>
        /// String do Conexao.
        /// </summary>
        private static string conexao = "Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=DBEmpresaFarias;Integrated Security=True";
        private SqlConnection ConexaoSQL = new SqlConnection(conexao);
        /// <summary>
        /// Metodo para obter uma conexao.
        /// </summary>
        /// <returns>Uma nova conexao ao Banco de Dados.</returns>
        public SqlConnection ObterConexao()
        {
             return ConexaoSQL;
        }
        /// <summary>
        /// Metodo para fechar uma conexao.
        /// </summary>
        /// <param name="con">Conexao a ser fechada.</param>
        public void FecharConexao(SqlConnection con)
        {
            if (con != null)
            {
                 con.Close();
            }
        }

    }
}
