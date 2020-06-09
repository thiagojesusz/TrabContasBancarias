using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    class Corrente :ISacavel
    {
        private static double aliquota=1;
        private static double tarifa = 10.0;
        private double saldo;
        private double limite;

        
        public Corrente(double saldo, double limite)
        {
            this.saldo = saldo;
            this.limite = limite;
        }

        public double cobrarTarifa()
        {
            return saldo -= tarifa;
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
            return saldo += aliquota;
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
