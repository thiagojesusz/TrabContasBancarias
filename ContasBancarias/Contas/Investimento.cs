using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    class Investimento : ISacavel
    {
        /// <summary>
        /// Atributos da classe
        /// </summary>
        #region Atributos da classe
        private static double aliquota = 10;
        private static double tarifa = 3;
        private double saldo;
        #endregion

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="saldo"></param>
        #region Construtor da classe
        public Investimento(double saldo)
        {
            this.saldo = saldo;
        }
        #endregion

        /// <summary>
        /// Método para cobrar as tarifas das contas
        /// </summary>
        /// <returns></returns>
        #region Cobrar Tarifa
        public double cobrarTarifa()
        {
            saldo -= tarifa;
            return tarifa;
        }
        #endregion

        /// <summary>
        /// Método para depositar o valor nas contas
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        #region Depositar
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
        #endregion

        /// <summary>
        /// Método para calcular o rendimentos das contas
        /// </summary>
        /// <returns></returns>
        #region Rendimento
        public double rendimento()
        {
            double rendim = aliquota - tarifa;
            saldo += rendim;

            return rendim;
        }
        #endregion

        /// <summary>
        /// Método para sacar o valor das contas
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        #region Sacar
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
        #endregion

        /// <summary>
        /// Método para retornar o saldo atual das contas
        /// </summary>
        /// <returns></returns>
        #region Saldo Atual
        public double saldoAtual()
        {
            return saldo;
        }
        #endregion

        /// <summary>
        /// Método para retornar o ToString() da conta
        /// </summary>
        /// <returns></returns>
        #region ToString
        public override string ToString()
        {
            return "Conta Investimento";
        }
        #endregion

    }
}
