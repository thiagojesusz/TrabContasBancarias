using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ContasBancarias
{
    class Conta
    {
        private string nomeTitular;
        private ISacavel categoria;
        private int numConta;
        private double saldo = 0;
        private DateTime dataAbertura;
        private List<string> listaExtrato = new List<string>();

        public Conta(int numConta, string nome, double valor, ISacavel tipo)
        {
            this.numConta = numConta;
            this.saldo = valor;
            this.categoria = tipo;
            this.dataAbertura = DateTime.Now;
            this.nomeTitular = nome;
        }

        public string extrato()
        {
            foreach(string x in listaExtrato)
            {
                return x;
            }
            return "";
        }

        public double rendimento()
        {
            return saldo * 0.01;
        }

        public double tarifa()
        {
            return 4.50;
        }

        public bool saque(double valor)
        {
            saldo -= valor;
            DateTime hoje = DateTime.Now;
            listaExtrato.Add("Saque de " + valor.ToString("F2") + " feito do dia " + hoje);
            return true;
        }

        public bool deposito(double valor)
        {
            saldo += valor;
            DateTime hoje = DateTime.Now;
            listaExtrato.Add("Deposito de " + valor.ToString("F2") + " feito do dia " + hoje);
            return true;
        }
    }
}
