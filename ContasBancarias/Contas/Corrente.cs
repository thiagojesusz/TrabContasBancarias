using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    class Corrente :ISacavel
    {
        private static double aliquota=2;
        private static double tarifa = 3;
        private double saldo;
        private static double limite = 100;
        // ps: mudar método rendimento.
        public double cobrarTarifa()
        {
            saldo -= tarifa;

            return tarifa;
        }

        public bool depositar(double valor)
        {
            if (valor > 0)
            {
                saldo += valor;
                return true;
            }
            else
                return false;
        }

        public double rendimento()
        {
            saldo += aliquota;
            return aliquota;
        }

        public bool sacar(double valor)
        {
            if (saldo - valor < 0)
                cobrarTarifa();
            if ((saldo - valor) >= (limite * (-1)))
            {
                this.saldo -= valor;
                return true;
            }
            else
                return false;

        }

        public double saldoAtual()
        {
            return saldo;
        }
    }
}
