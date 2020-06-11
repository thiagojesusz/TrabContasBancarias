using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    class Qualificado: Cliente
    {
        /// <summary>
        /// Atributo da classe
        /// </summary>
        #region Atributo da classe
        private static double desconto = 3;
        #endregion

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="CPF"></param>
        /// <param name="nome"></param>
        #region Construtor da classe
        public Qualificado(string CPF, string nome) : base(CPF, nome)
        {
            this.CPF = CPF;
            this.nome = nome;
            this.contas = new List<Conta>();
        }
        #endregion

        /// <summary>
        /// Método para cobrar a taxa do cliente de acordo com a categoria "Qualificado"
        /// </summary>
        /// <param name="valorOriginal"></param>
        /// <returns></returns>
        #region regras de negócio
        public override double cobrarTaxa(double valorOriginal)
        {
            return valorOriginal - desconto;
        }
        public override string ToString()
        {
            return "Nome: " + this.nome + " CPF: " + this.CPF + " Cliente Qualificado / Desconto de R$"+desconto.ToString("F2") + " por taxa";
        }
        #endregion

    }
}
