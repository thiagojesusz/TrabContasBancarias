using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    abstract class Cliente
    {
        protected string CPF;
        protected string nome;
        protected List<Conta> contas;
        
        public Cliente(string CPF, string nome)
        {
            this.CPF = CPF;
            this.nome = nome;
         
        }
        public string getNome() { return nome; }
        public string getCPF() { return CPF; }

        public abstract string extrato(int numconta);
        public abstract double totalTaxas();
        public abstract double totalrendimentos();
        public abstract double cobrarTaxa(double valorOriginal);
    }
}
