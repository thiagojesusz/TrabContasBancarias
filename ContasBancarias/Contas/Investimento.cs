﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    class Investimento : ISacavel
    {
        private static double aliquota = 10;
        private static double tarifa = 4;
        private double saldo;
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
            double rendim = aliquota - tarifa;
            saldo += aliquota;

            return rendim;
        }

        public bool sacar(double valor)
        {
            if ((valor > 0) && ((saldo - valor) >= 0))
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
