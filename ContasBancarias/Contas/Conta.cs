using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ContasBancarias
{
    class Conta
    {
        /// <summary>
        /// Atributos da classe
        /// </summary>
        #region Atributos da classe
        private string CPFTitular;
        private ISacavel categoria;
        private int numConta;
        private DateTime dataAbertura;
        private List<string> listaExtrato = new List<string>();
        private Operacao operacao;
        private double saldo, saldoInical;
        private double totalRendimentos;
        private double totalTaxas;
        #endregion

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="numConta"></param>
        /// <param name="tipo"></param>
        /// <param name="CPF"></param>
        /// <param name="saldo"></param>
        #region Construtor da classe
        public Conta(int numConta, int tipo, string CPF, double saldo)
        {
            this.numConta = numConta;
            this.dataAbertura = DateTime.Now;
            this.CPFTitular = CPF;
            this.saldo = saldo;
            this.saldoInical = saldo;
            if (tipo == 0)
                this.categoria = new Corrente(this.saldo);
            else if (tipo == 1)
                this.categoria = new Investimento(this.saldo);
        }
        #endregion

        /// <summary>
        /// Getters e Setters da classe
        /// </summary>
        /// <returns></returns>
        #region Getters e Setters
        public string getCPFTitular() { return CPFTitular; }
        public int getNumConta() { return numConta; }
        public DateTime getDataAbertura() { return dataAbertura; }
        public double getSaldo() { return saldo; }
        public double getTotalRendimentos() { return totalRendimentos; }
        public double getTotalTaxas() { return totalTaxas; }
        public void setSaldo(double saldo) { this.saldo = saldo; }
        public void setTotalTaxas(double taxa) { this.totalTaxas += taxa; }
        #endregion

        /// <summary>
        /// Método para atualizar o extrato da conta do cliente
        /// </summary>
        /// <returns></returns>
        #region Extrato
        public string extrato()
        {
            StringBuilder aux = new StringBuilder("-------------- EXTRATO --------------\n");
            aux.AppendLine("\n" + categoria.ToString() + " Titular: " + CPFTitular + " Conta: " + numConta.ToString("D4"));
            aux.AppendLine("\n Saldo Inicial: " + saldoInical);
            foreach (string ext in listaExtrato)
            {
                aux.AppendLine(ext);
            }
            aux.AppendLine("Saldo atual: R$" + this.saldo.ToString("F2"));

            return aux.ToString();
        }
        #endregion

        /// <summary>
        /// Método para verificar a regra de saque das contas
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        #region Saque
        public bool saque(double valor)
        {
            bool verificar = true;
            operacao = new Saque(valor);
            verificar = categoria.sacar(valor);
            if (verificar == true)
            {
                operacao.atualizar(this);
                listaExtrato.Add(operacao.ToString());
            }
            return verificar;
        }
        #endregion

        /// <summary>
        /// Método para verificar a regra de deposito das contas
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        #region Deposito
        public bool deposito(double valor)
        {
            bool verificar = true;
            operacao = new Deposito(valor);
            verificar = categoria.depositar(valor);
            if (verificar == true)
            {
                operacao.atualizar(this);
                listaExtrato.Add(operacao.ToString());
            }
            return verificar;
        }
        #endregion

        /// <summary>
        /// Método para calcular o rendimento das contas
        /// </summary>
        /// <returns></returns>
        #region Rendimento
        public double rendimento()
        {

            double valor;
            valor = categoria.rendimento();
            this.saldo += valor;

            totalRendimentos += valor;
            listaExtrato.Add((DateTime.Now + " - Rendimento no valor de R$" + valor.ToString("F2")).ToString());

            return totalRendimentos;
        }
        #endregion

        /// <summary>
        /// Método para cobrar a tarifa das contas
        /// </summary>
        /// <returns></returns>
        #region Tarifa
        public double tarifa()
        {
            double valor;
            valor = categoria.cobrarTarifa();
            this.saldo -= valor;
            totalTaxas += valor;

            return valor;
        }
        #endregion

    }
}
