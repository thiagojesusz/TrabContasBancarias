﻿using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
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
        public Corrente(double saldo)
        {
            this.saldo = saldo;
        }
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
            bool ver = false;
            if ((saldo - valor) >= (limite * (-1)))
            {

                ver = true;
            }
            else
                ver = false;

            if (saldo - valor < 0)
            {
                cobrarTarifa();

            }
            return ver;
        }
        public double saldoAtual()
        {
            return saldo;
        }
        public override string ToString()
        {
            return "Conta Corrente";
        }
    }
}
