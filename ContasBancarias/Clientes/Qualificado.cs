using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    class Qualificado: Cliente
    {
        public Qualificado(string CPF, string nome) : base(CPF, nome)
        {
            this.CPF = CPF;
            this.nome = nome;
            this.contas = new List<Conta>();
        }
        public override double cobrarTaxa(double valorOriginal)
        {
            return 2;
        }
    }
}
