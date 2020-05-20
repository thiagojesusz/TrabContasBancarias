using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    class Investimento: ISacavel
    {
        private double saldo;
        private double limite;

        public double cobrarTarifa()
        {

        }

        public bool depositar(double valor)
        {
            saldo += valor;
        }

        public double rendimento()
        {

        }

        public bool sacar(double valor)
        {

        }

        public double saldoAtual()
        {

        }
    }
}
