using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    class Deposito: Operacao
    {
        public override string atualizar(double valor)
        {
            Data = DateTime.Now;

            return (Data + " - Depósito no valor de R$" + valor.ToString("F2")).ToString();
        }
    }
}
