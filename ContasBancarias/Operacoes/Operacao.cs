using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    abstract class Operacao
    {
        protected DateTime Data;

        public abstract string atualizar(double valor);
    }
}
