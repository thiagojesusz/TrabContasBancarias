using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    class Deposito: Operação
    {
        public override bool atualizar(Conta conta)
        {
            return true;
        }
    }
}
