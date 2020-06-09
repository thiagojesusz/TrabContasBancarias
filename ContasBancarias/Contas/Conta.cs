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
        public int tipo;
        private int numConta;
        private double saldo;
        private DateTime dataAbertura;
        private List<string> listaExtrato = new List<string>();

        public Conta(int numConta, string nome, double saldo, int tipo)
        {
            this.numConta = numConta;
            this.saldo = saldo;
            this.tipo = tipo;
            this.dataAbertura = DateTime.Now;
            this.nomeTitular = nome;
        }

        public string getNomeTituloar() { return nomeTitular; }
        public int getNumConta() { return numConta; }
        public double getSaldo() { return saldo; }
        public DateTime getDataAbertura() { return dataAbertura; }

        public string extrato()
        {
            StringBuilder aux = new StringBuilder();

            aux.AppendLine("Titular: "+nomeTitular+" Conta: "+numConta+" Categoria: "+tipo);
            foreach (string ext in listaExtrato)
            {
                aux.AppendLine(ext);
            }
            aux.AppendLine("Saldo atual: R$ " + saldo.ToString("F2"));
            return aux.ToString();
        }

        // public abstract double rendimento();

       // public abstract double tarifa();

        public bool saque(double valor)
        {
            saldo -= valor;
            DateTime hoje = DateTime.Now;
            listaExtrato.Add("Saque de " + valor.ToString("F2") + " Data: " + hoje.ToString());
            return true;
        }

        public bool deposito(double valor)
        {
            saldo += valor;
            DateTime hoje = DateTime.Now;
            listaExtrato.Add("Deposito de " + valor.ToString("F2") + " Data: " + hoje.ToString());
            return true;
        }
    }
}
