using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    abstract class Operação
    {
        private double valor;
        private DateTime Data;

        public virtual bool atualizar(Conta conta)
        {
            return true;
        }
    }
}
