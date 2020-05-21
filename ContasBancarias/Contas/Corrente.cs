using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    class Corrente
    {
        private double saldo;
        private double limite;

        public double cobrarTarifa()
        {
            return saldo -= 10.0;
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
            return 0;
        }

        public bool sacar(double valor)
        {
            if (saldo + limite >= valor)
            {
                saldo -= valor;
            }
            return true;
        }

        public double saldoAtual()
        {
            return saldo;
        }
    }
}
