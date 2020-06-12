using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    abstract class Operacao
    {
        /// <summary>
        /// Atributos da conta
        /// </summary>
        #region Atributos
        protected double valor;
        protected DateTime Data;
        #endregion

        /// <summary>
        /// 1º Construtor
        /// </summary>
        /// <param name="valor"></param>
        #region Construtor 01
        public Operacao(double valor, DateTime data)
        {
            this.valor = valor;
            this.Data = data;
        }
        #endregion

        /// <summary>
        /// 2º Construtor
        /// </summary>
        #region Construtor 02
        public Operacao()
        {
            this.Data = DateTime.Now;
        }
        #endregion

        /// <summary>
        /// Método que será implementado pelas classes que irão utlizar a Operação
        /// </summary>
        /// <param name="conta"></param>
        /// <returns></returns>
        #region Atualizar
        public abstract bool atualizar(Conta conta);
        #endregion

    }
}
