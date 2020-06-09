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
        private Operacao saq;
        private Operacao depos;
        private double saldoInicial;

        private double totalRendimentos;
        private double totalTaxas;

        public Conta(int numConta, int tipo, string CPF, double saldo)
        {
            this.numConta = numConta;
            this.dataAbertura = DateTime.Now;
            this.CPFTitular = CPF;
            this.tipo = tipo;
            this.saldoInicial = saldo;
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
            StringBuilder aux = new StringBuilder("-------------- EXTRATO --------------\n");
            if (tipo == 0)
                aux.AppendLine("\nTitular: " + CPFTitular + " Conta: " + numConta.ToString("D4") + " Tipo de Conta: Conta Corrente");

            else if (tipo == 1)
                aux.AppendLine("\nTitular: " + CPFTitular + " Conta: " + numConta.ToString("D4") + " Tipo de Conta: Conta Investimento");

            aux.AppendLine("\nSaldo Anterior: R$" +saldoInicial.ToString("F2"));
            foreach (string ext in listaExtrato)
            {
                aux.AppendLine(ext);
            }
            if (tipo == 0)
            aux.AppendLine("Saldo atual: R$" + contCorrente.saldoAtual().ToString("F2"));
             if (tipo ==1)
            aux.AppendLine("Saldo atual: R$" + contInvestimento.saldoAtual().ToString("F2"));

            return aux.ToString();
        }

        public bool saque(double valor)
        {
            bool verificar=true;
            saq = new Saque();
            if (tipo == 0)
            verificar = contCorrente.sacar(valor);
            else if (tipo == 1)
            verificar = contInvestimento.sacar(valor);

            if (verificar == true)
                listaExtrato.Add(saq.atualizar(valor));

            return verificar;

        }

        public bool deposito(double valor)
        {
            bool verificar = true;
            depos = new Deposito();
            if (tipo == 0)
                verificar = contCorrente.depositar(valor);
            else if (tipo == 1)
                verificar = contInvestimento.depositar(valor);

            if (verificar == true)
                listaExtrato.Add(depos.atualizar(valor));

            return verificar;
        }
        public double rendimento()
        {
            if (tipo == 0)
                totalRendimentos += contCorrente.rendimento();
            else if (tipo == 1)
                totalRendimentos += contInvestimento.rendimento();

            return totalRendimentos;
        }

        public double tarifa()
        {
            if (tipo == 0)
               totalTaxas += contCorrente.cobrarTarifa();
            else if (tipo == 1)
                totalTaxas += contInvestimento.cobrarTarifa();
            return totalRendimentos;
        }
    }
}
