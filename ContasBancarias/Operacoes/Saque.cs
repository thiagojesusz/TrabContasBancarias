using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    class Saque: Operacao
    {
        public override string atualizar(double valor)
        {
             Data = DateTime.Now;

            return (Data + " - Saque no valor de R$" + valor.ToString("F2")).ToString();
        }
    }
}
