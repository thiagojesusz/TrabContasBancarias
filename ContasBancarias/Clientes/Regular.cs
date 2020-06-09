using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    class Regular: Cliente
    {
        public Regular(string CPF, string nome) : base(CPF, nome)
        {
            this.CPF = CPF;
            this.nome = nome;

        }
        public override double cobrarTaxa(double valorOriginal)
        {
            return 2;
        }
    }
}
