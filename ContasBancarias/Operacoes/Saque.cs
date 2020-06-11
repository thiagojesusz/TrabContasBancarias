using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    class Saque: Operacao
    {
        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="valor"></param>
        #region Construtor
        public Saque(double valor) : base(valor)
        {
            this.valor = valor;
            this.Data = DateTime.Now;
        }
        #endregion

        /// <summary>
        /// Método para atualizar o saldo da conta apos a operação
        /// </summary>
        /// <param name="conta"></param>
        /// <returns></returns>
        #region Atualizar
        public override bool atualizar(Conta conta)
        {
            double saldoatual;
            saldoatual = (conta.getSaldo() - valor);
            conta.setSaldo(saldoatual);

            return true;
        }
        #endregion

        /// <summary>
        /// Método para retornar o ToString() da conta apos a operação
        /// </summary>
        /// <returns></returns>
        #region ToString
        public override string ToString()
        {
            return (Data + " - Saque no valor de R$" + valor.ToString("F2")).ToString();
        }
        #endregion

    }
}
