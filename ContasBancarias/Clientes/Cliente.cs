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
        public abstract double cobrarTaxa(double valorOriginal);
    }
}
