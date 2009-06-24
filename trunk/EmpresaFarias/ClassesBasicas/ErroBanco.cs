using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excecoes
{   ///<summary>
    ///Classe Responsavel pelos erros relacionados ao Banco, Herda de Exception.
    ///</summary>
    public class ErroBanco : Exception
    {
        /// <summary>
        /// Construtor padrão do ErroBanco.
        /// </summary>
        public ErroBanco()
        {

        }
        /// <summary>
        /// Construtor com argumento.
        /// </summary>
        /// <param name="arg0">Argumento a ser passado.</param>
        public ErroBanco(String arg0) :
            base(arg0)
        {

        }
    }
}
