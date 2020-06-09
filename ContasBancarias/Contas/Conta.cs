using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ContasBancarias
{
    class Conta
    {
        private string CPFTitular;
        private ISacavel contInvestimento;
        private ISacavel contCorrente;
        private int numConta;
        private DateTime dataAbertura;
        private int tipo;
        private List<string> listaExtrato = new List<string>();

        public Conta(int numConta, int tipo, string CPF, double saldo)
        {
            this.numConta = numConta;
            this.dataAbertura = DateTime.Now;
            this.CPFTitular = CPF;
            this.tipo = tipo;
            this.contInvestimento = new Investimento();
            this.contCorrente = new Corrente();
            if (tipo == 0)
            {
                contCorrente.depositar(saldo);
            }
            else if (tipo == 1)
            {
                contInvestimento.depositar(saldo);
            }
        }

        public string getCPFTitular() { return CPFTitular; }
        public int getNumConta() { return numConta; }
        public DateTime getDataAbertura() { return dataAbertura; }

        public string extrato()
        {
            StringBuilder aux = new StringBuilder();
            if(tipo ==0)
            aux.AppendLine("Titular: "+CPFTitular+" Conta: "+numConta.ToString("D4")+" Tipo de Conta: Conta Corrente");
            else if(tipo ==1)
            aux.AppendLine("Titular: " + CPFTitular + " Conta: " + numConta.ToString("D4") + " Tipo de Conta: Conta Investimento");
            foreach (string ext in listaExtrato)
            {
                aux.AppendLine(ext);
            }
            if (tipo == 0)
            aux.AppendLine("Saldo atual: R$ " + contCorrente.saldoAtual().ToString("F2"));
             if (tipo ==1)
            aux.AppendLine("Saldo atual: R$ " + contInvestimento.saldoAtual().ToString("F2"));

            return aux.ToString();
        }

        // public abstract double rendimento();

       // public abstract double tarifa();

        public bool saque(double valor)
        {

            DateTime hoje = DateTime.Now;
            listaExtrato.Add("Saque de " + valor.ToString("F2") + " Data: " + hoje.ToString());
            return true;
        }

        public bool deposito(double valor)
        {
            DateTime hoje = DateTime.Now;
            listaExtrato.Add("Deposito de " + valor.ToString("F2") + " Data: " + hoje.ToString());
            return true;
        }
    }
}
