using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    class Deposito: Operacao
    {
        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="valor"></param>
        #region Construtor da classe
        public Deposito(double valor, DateTime data) : base(valor,data)
        {
            this.valor = valor;
            this.Data = data;
        }
        #endregion

        /// <summary>
        /// Método para atualizar o saldo da conta apos a opreção
        /// </summary>
        /// <param name="conta"></param>
        /// <returns></returns>
        #region Atualizar
        public override bool atualizar(Conta conta)
        {
            double saldoatual;
            saldoatual = conta.getSaldo() + valor;
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
            return (Data + " - Depósito no valor de R$" + valor.ToString("F2")).ToString();
        }
        #endregion

    }
}
