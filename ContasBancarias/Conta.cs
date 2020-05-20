using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    class Conta
    {
        private ISacavel categoria;
        private int numConta;
        private double saldoInicial = 0;
        private DateTime dataAbertura;

        public Conta(int numConta, double valor, ISacavel tipo)
        {
            this.numConta = numConta;
            saldoInicial = valor;
            categoria = tipo;
            dataAbertura = DateTime.Now;
        }
    }
}
