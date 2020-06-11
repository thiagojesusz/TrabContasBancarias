using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    class Deposito: Operacao
    {
        public Deposito(double valor) : base(valor)
        {
            this.valor = valor;
        }
        public override bool atualizar(Conta conta)
        {
            double saldoatual;
            saldoatual = conta.getSaldo() + valor;
            conta.setSaldo(saldoatual);

            return true;
        }

        public override string ToString()
        {
            return (Data + " - Depósito no valor de R$" + valor.ToString("F2")).ToString();
        }
    }
}
