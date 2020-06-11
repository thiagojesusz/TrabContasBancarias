using System;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace ContasBancarias
{
    class Program
    {
        static List<Conta> carregarContas()
        {
            List<Conta> contas = new List<Conta>();
            using (StreamReader arq = new StreamReader(@"C:\Users\thiag\Desktop\TrabalhoFinal\Dados\dadosContasPOO.txt")) // dadosContasPOO
            {
                string reader;

                while (!arq.EndOfStream)
                {
                    reader = arq.ReadLine();
                    string[] pos_arq = reader.Split(';');

                    Conta c = new Conta(int.Parse(pos_arq[0]), int.Parse(pos_arq[1]), pos_arq[2], double.Parse(pos_arq[3]));
                    contas.Add(c);
                }
            }
            return contas;
        }

        static void carregarOperacoes(List<Conta> contas)
        {
            using (StreamReader arq = new StreamReader(@"C:\Users\thiag\Desktop\TrabalhoFinal\Dados\dadosOperacoesBancoPOO.txt")) // dadosContasPOO
            {
                string reader;
                while (!arq.EndOfStream)
                {
                    reader = arq.ReadLine();
                    string[] pos_arq = reader.Split(';');
                    int numConta = int.Parse(pos_arq[0]);

                    foreach (Conta conta in contas)
                    {

                        if (conta.getNumConta() == numConta)
                        {
                            switch (pos_arq[1])
                            {
                                case "0":
                                    conta.saque(double.Parse(pos_arq[2]));
                                    break;

                                case "1":
                                    conta.deposito(double.Parse(pos_arq[2]));
                                    break;

                                case "2":
                                    //conta.rendimento(double.Parse(pos_arq[2]));
                                    break;

                                default:
                                    break;
                            }
                            conta.saque(int.Parse(pos_arq[2]));
                        }
                    }
                }
            }
        }

        static List<Cliente> carregarClientes(List<Conta> conta)
        {
            List<Cliente> clientes = new List<Cliente>();
            using (StreamReader arq = new StreamReader(@"C:\Users\thiag\Desktop\TrabalhoFinal\Dados\dadosClientesPOO.txt")) // dadosClientesPOO
            {
                string reader;

                while (!arq.EndOfStream)
                {
                    reader = arq.ReadLine();
                    string[] pos_arq = reader.Split(';');

                    switch (pos_arq[2])
                    {
                        case "0":
                            Regular r = new Regular(pos_arq[0], pos_arq[1]);
                            clientes.Add(r);
                            foreach(Conta cont in conta)
                            {
                                if (cont.getCPFTitular().Equals(r.getCPF()))
                                    r.addConta(cont);
                            }                  
                            break;
                        case "1":
                            Qualificado q = new Qualificado(pos_arq[0], pos_arq[1]);
                            clientes.Add(q);
                            foreach (Conta cont in conta)
                            {
                                if (cont.getCPFTitular().Equals(q.getCPF()))
                                    q.addConta(cont);
                            }
                            break;
                        case "2":
                            Premium p = new Premium(pos_arq[0], pos_arq[1]);
                            clientes.Add(p);
                            foreach (Conta cont in conta)
                            {
                                if (cont.getCPFTitular().Equals(p.getCPF()))
                                    p.addConta(cont);
                            }
                            break;
                        default: throw new ArgumentException("Tipo de cliente desconhecido");
                    }

                }
            }
            return clientes;
        }

        static void Main(string[] args)
        {
            List<Conta> minhasContas = carregarContas();
            List<Cliente> meusClientes = carregarClientes(minhasContas);       
            carregarOperacoes(minhasContas);
        }
    }
}
