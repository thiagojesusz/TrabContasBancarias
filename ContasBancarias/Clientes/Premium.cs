using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ContasBancarias
{
    class Premium: Cliente
    {
        public Premium(string CPF, string nome) :base(CPF,nome)
        {
            this.CPF = CPF;
            this.nome = nome;

        }
        public override double cobrarTaxa(double valorOrignal)
        {
            return 2;
        }
    }
}
