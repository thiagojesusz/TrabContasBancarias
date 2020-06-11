using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ContasBancarias
{
    abstract class Cliente
    {
        /// <summary>
        /// Atributos da classe
        /// </summary>
        #region Atributos da classe
        protected string CPF;
        protected string nome;
        protected List<Conta> contas;
        #endregion

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="CPF"></param>
        /// <param name="nome"></param>
        #region Construtor da classe
        public Cliente(string CPF, string nome)
        {
            this.CPF = CPF;
            this.nome = nome;
            this.contas = new List<Conta>();
        }
        #endregion

        /// <summary>
        /// Getters da classe
        /// </summary>
        /// <returns></returns>
        #region Geters da classe
        public string getNome() { return nome; }
        public string getCPF() { return CPF; }
        public string GetContas()
        {
            StringBuilder aux = new StringBuilder();
            foreach (Conta c in contas)
            {
                aux.AppendLine(c.getNumConta().ToString());
            }
            return aux.ToString();
        }
        #endregion 

        /// <summary>
        /// Método para adicionar uma conta a lista de contas
        /// </summary>
        /// <param name="conta"></param>
        #region Adicionar Conta
        public void addConta(Conta conta)
        {
            contas.Add(conta);
        }
        #endregion

        /// <summary>
        /// Método que procura a conta na lista de conta e retorna seu extrato
        /// </summary>
        /// <param name="numconta"></param>
        /// <returns></returns>
        #region Extrato
        public string extrato(int numconta)
        {
            string extrato;

            extrato = contas.Find(x => x.getNumConta() == numconta).extrato();

            return extrato;
        }
        #endregion

        /// <summary>
        /// Método para retornar o total de taxas
        /// </summary>
        /// <returns></returns>
        #region Total de Taxas
        public double totalTaxas()
        {
            double totalTaxas = 0;
            foreach (Conta cont in contas)
            {
                totalTaxas += cont.getTotalTaxas();
            }
            return totalTaxas;
        }
        #endregion

        /// <summary>
        /// Método para retornar o total de rendimentos da conta
        /// </summary>
        /// <returns></returns>
        #region Total Rendimentos
        public double totalRendimentos()
        {
            double rendimentos = 0;
            foreach (Conta cont in contas)
            {
                rendimentos += cont.getTotalTaxas();
            }
            return rendimentos;
        }
        #endregion

        /// <summary>
        /// Método para cobrar a taxa dos clientes
        /// </summary>
        /// <param name="valorOriginal"></param>
        /// <returns></returns>
        #region Cobrar Taxa
        public abstract double cobrarTaxa(double valorOriginal);
        #endregion

    }
}
