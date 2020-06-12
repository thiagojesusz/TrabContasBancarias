using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    class Regular: Cliente
    {
        /// <summary>
        /// Atributo da classe
        /// </summary>
        #region Atributo da classe
        private static double desconto = 1;
        #endregion

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="CPF"></param>
        /// <param name="nome"></param>
        #region Construtor da classe
        public Regular(string CPF, string nome) : base(CPF, nome)
        {
            this.CPF = CPF;
            this.nome = nome;
            this.contas = new List<Conta>();
        }
        #endregion

        /// <summary>
        /// Método para cobrar a taxa do cliente de acordo com a categoria "Regular"
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
            return "Nome: " + this.nome + " CPF: " + this.CPF + " Cliente Regular ";
        }
        #endregion
    }
}
