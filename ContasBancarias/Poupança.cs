using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    class Poupança : ISacavel
    {
        private double saldo;
        public double cobrarTarifa()
        {

        }

        public bool depositar(double valor)
        {
            if (valor > 0)
            {
                saldo += valor;
            }
            return true;
        }

        public double rendimento()
        {
            saldo *= 0.2;
            return saldo;
        }

        public bool sacar(double valor)
        {
            if (saldo > valor)
            {
                saldo -= valor;
                return true;
            }
            else
            {
                return false;
            }
        }

        public double saldoAtual()
        {

        }
    }
}
