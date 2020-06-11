using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    class Qualificado: Cliente
    {
        private static double desconto = 3;
        public Qualificado(string CPF, string nome) : base(CPF, nome)
        {
            this.CPF = CPF;
            this.nome = nome;
            this.contas = new List<Conta>();
        }
        public override double cobrarTaxa(double valorOriginal)
        {
            return valorOriginal - desconto;
        }
    }
}
