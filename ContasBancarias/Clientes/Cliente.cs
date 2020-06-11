using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
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
            this.contas = new List<Conta>();
        }
        public string getNome() { return nome; }
        public string getCPF() { return CPF; }
        public string GetContas()
        {
            StringBuilder aux = new StringBuilder();
            foreach(Conta c in contas)
            {
                aux.AppendLine(c.getNumConta().ToString());
            }
            return aux.ToString();
        }
        public void addConta(Conta conta)
        {
            contas.Add(conta);
        }
        public string extrato(int numconta)
        {
            string extrato;

            extrato =  contas.Find(x => x.getNumConta() == numconta).extrato();
    
            return extrato;
        }

        //public abstract double totalTaxas();
        //public abstract double totalrendimentos();
        public abstract double cobrarTaxa(double valorOriginal);
    }
}
