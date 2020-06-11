using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    abstract class Operacao
    {
        protected double valor;
        protected DateTime Data;

        public Operacao(double valor) {
            this.valor = valor;
            this.Data = DateTime.Now;
        }
        public abstract bool atualizar(Conta conta);
    }
}
