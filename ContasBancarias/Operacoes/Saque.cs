using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    class Saque: Operacao
    {
        public Saque(double valor) : base(valor)
        {
            this.valor = valor;
        }
        public override bool atualizar(Conta conta)
        {
            double saldoatual;
            saldoatual = (conta.getSaldo() - valor);
            Console.WriteLine(saldoatual);
            conta.setSaldo(saldoatual);

            return true;
        }
        public override string ToString()
        {
            return (Data + " - Saque no valor de R$" + valor.ToString("F2")).ToString();
        }
    }
}
