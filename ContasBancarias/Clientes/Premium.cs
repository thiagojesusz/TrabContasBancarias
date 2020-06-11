using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ContasBancarias
{
    class Premium: Cliente
    {
        private static double desconto = 5;
        public Premium(string CPF, string nome) :base(CPF,nome)
        {
            this.CPF = CPF;
            this.nome = nome;
            this.contas = new List<Conta>();
        }
        public override double cobrarTaxa(double valorOrignal)
        {
            return valorOrignal - desconto;
        }
    }
}
