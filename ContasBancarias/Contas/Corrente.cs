using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ContasBancarias
{
    class Corrente :ISacavel
    {
        /// <summary>
        /// Atributos da classe
        /// </summary>
        #region Atributos da classe
        private static double aliquota = 2;
        private static double tarifa = 3;
        private double saldo;
        private static double limite = 1000;
        #endregion

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="saldo"></param>
        #region Construtor da classe
        public Corrente(double saldo)
        {
            this.saldo = saldo;
        }
        #endregion

        /// <summary>
        /// Método para cobrar a tarifa das contas
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
        /// Metodo para calcular o rendimento da contas
        /// </summary>
        /// <returns></returns>
        #region Rendimento
        public double rendimento()
        {
            saldo += aliquota;
            return aliquota;
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
        #endregion

        /// <summary>
        /// Método para retonar o saldo atual das contas
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
            return "Categoria: Corrente";
        }
        #endregion

    }
}
