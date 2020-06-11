using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ContasBancarias
{
    class Premium: Cliente
    {
        /// <summary>
        /// Atributo da classe
        /// </summary>
        #region Atributo da classe
        private static double desconto = 5;
        #endregion

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="CPF"></param>
        /// <param name="nome"></param>
        #region Construtor da classe
        public Premium(string CPF, string nome) : base(CPF, nome)
        {
            this.CPF = CPF;
            this.nome = nome;
            this.contas = new List<Conta>();
        }
        #endregion

        /// <summary>
        /// Método para cobrar a taxa de acordo com a categoria "Premium"
        /// </summary>
        /// <param name="valorOrignal"></param>
        /// <returns></returns>
        #region Cobrar Taxa
        public override double cobrarTaxa(double valorOrignal)
        {
            return valorOrignal - desconto;
        }
        #endregion

    }
}
