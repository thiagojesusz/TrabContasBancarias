using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    abstract class Cliente
    {
        private string cpf;
        private string nome;

        public abstract string extrato(int numConta);

        public abstract double totalTaxas();

        public abstract double totalRendimento();

        public abstract double cobrarTaxa();
    }
}
