using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesBasicas
{   ///<summary>
    ///Classe Responsavel pelos erros de Negocio, Herda de Exception.
    ///</summary>
    public class ExcecaoNegocio : Exception
    {
        /// <summary>
        /// Construtor padrão do ErroBanco.
        /// </summary>
        public ExcecaoNegocio()
        {

        }
        /// <summary>
        /// Construtor com argumento.
        /// </summary>
        /// <param name="arg0">Argumento a ser passado.</param>
        public ExcecaoNegocio(String arg0) :
            base(arg0)
        {

        }
    }
}
