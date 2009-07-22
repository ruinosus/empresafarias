using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesBasicas
{
    /// <summary>
    /// Enum que representa os status do Banco.
    /// </summary>
    public enum StatusBanco
    {
        Inativo = 1,
        Inclusao,
        Alteracao,
        Navegacao
    }   

    /// <summary>
    /// Enum que representa os Status referente a um Titular/Dependente/Contrato/Parcela/Usuario.
    /// </summary>
    public enum StatusControle
    {
        Ativo = 1,
        InativoFaltaPagamento,
        InativoObito,
        InativoCancelamentoContrato,
        InativoExlusao,
        EmDia,
        Atrasada,

    }

    
}
