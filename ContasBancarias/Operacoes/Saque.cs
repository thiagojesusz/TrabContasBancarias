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
            this.Data = DateTime.Now;
        }
        public override bool atualizar(Conta conta)
        {
            double saldoatual;
            saldoatual = (conta.getSaldo() - valor);
            conta.setSaldo(saldoatual);

            return true;
        }
        public override string ToString()
        {
            return (Data + " - Saque no valor de R$" + valor.ToString("F2")).ToString();
        }
    }
}
