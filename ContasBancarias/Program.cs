using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;

namespace ContasBancarias
{
    class Program
    {
        /// <summary>
        /// As contas carregadas são de origem de um arquivo.
        /// </summary>
        /// <returns>Método carregar as contas que retorna uma lista de contas.</returns>
        #region Carregar Contas
        static List<Conta> carregarContas()
        {
            List<Conta> contas = new List<Conta>();
            using (StreamReader arq = new StreamReader(@"C:\Users\thiag\Desktop\Final\TrabContasBancarias\dadosContasPOO.txt")) // dadosContasPOO
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
        #endregion

        /// <summary>
        /// Método para carregas as operações dos arquivos.
        /// </summary>
        /// <param name="contas"></param>
        #region Carregar Operações
        static void carregarOperacoes(List<Conta> contas)
        {
            using (StreamReader arq = new StreamReader(@"C:\Users\thiag\Desktop\Final\TrabContasBancarias\dadosOperacoesBancoPOO.txt")) // dadosContasPOO
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
                                    conta.rendimento();
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// Método para retonar a conta com maior saldo.
        /// </summary>
        /// <param name="minhasContas"></param>
        #region Conta com Maior Saldo
        static void contaMaiorSaldo(List<Conta> minhasContas)
        {
            double maior = 0;
            Conta maiorConta = new Conta(0, 0, "", 0);
            foreach (Conta cont in minhasContas)
            {
                if (cont.getSaldo() >= maior)
                {
                    maior = cont.getSaldo();
                    maiorConta = cont;
                }
            }
            Console.WriteLine("Conta com o maior saldo\n Número: " + maiorConta.getNumConta() + " Titular: " + maiorConta.getCPFTitular() + " Total: R$" + maiorConta.getSaldo().ToString("F2"));
        }
        #endregion

        /// <summary>
        /// Método para carregar os clientes dos arquivos.
        /// </summary>
        /// <param name="conta"></param>
        /// <returns></returns>
        #region Carregar Clientes
        static List<Cliente> carregarClientes(List<Conta> conta)
        {
            List<Cliente> clientes = new List<Cliente>();
            using (StreamReader arq = new StreamReader(@"C:\Users\thiag\Desktop\Final\TrabContasBancarias\dadosClientesPOO.txt")) // dadosClientesPOO
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
                            foreach (Conta cont in conta)
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
        #endregion

        /// <summary>
        /// Menu de interação com o usuário.
        /// </summary>
        /// <param name="minhasContas"></param>
        /// <param name="meusClientes"></param>
        #region Menu de Interação
        static void Menu(List<Conta> minhasContas, List<Cliente> meusClientes)
        {
        inicio:
            Console.WriteLine("---------NÃO É O BANCO INTER BANKING---------");
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1- Mostrar extrato de uma conta.");
            Console.WriteLine("2- Cobrar taxa do cliente.");
            Console.WriteLine("3- Mostrar ao cliente o total de taxas pagas.");
            Console.WriteLine("4- Mostrar a conta com maior saldo do banco.");

            int selecao = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (selecao)
            {
                case 1:
                    {
                        try
                        {
                            Console.WriteLine("Digite o CPF do Titular: ");
                            string CPF = Console.ReadLine();
                            Console.WriteLine("Digite o número da Conta: ");
                            int num = int.Parse(Console.ReadLine());
                            Console.Clear();
                            Cliente quem = meusClientes.Find(x => x.getCPF().Equals(CPF));
                            Conta qual = minhasContas.Find(x => x.getNumConta().Equals(num));
                            if (quem.getCPF() == qual.getCPFTitular())
                                Console.WriteLine(quem.extrato(qual.getNumConta()));
                            else
                            {
                                Console.WriteLine("CPF Inválido!");
                                goto case 1;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Valor inserido não é um número válido!");
                            goto case 1;
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Conta ou CPF não encontrado!");
                            goto case 1;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("ERRO!");
                            goto case 1;
                        }
                        break;
                    }
                case 2:
                    {
                        try
                        {
                            Console.Write("Digite o número da conta:");
                            int numConta = int.Parse(Console.ReadLine());
                            Conta findcont = minhasContas.Find(x => x.getNumConta().Equals(numConta));
                            Cliente findcliente = meusClientes.Find(x => x.getCPF().Equals(findcont.getCPFTitular()));
                            Console.Write("Informe o valor da taxa:");
                            double valorTaxa = double.Parse(Console.ReadLine());

                            double taxa = findcliente.cobrarTaxa(valorTaxa);
                            findcont.setTotalTaxas(taxa);
                            findcont.setSaldo(findcont.getSaldo() - taxa);
                            Console.WriteLine("------CLIENTE-----\n"+findcliente.ToString());
                            Console.WriteLine("Taxa cobrada no valor de R$" + taxa.ToString("F2") + " Devido ao desconto do cliente");

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Valor inserido não é um número válido!");
                            goto case 2;
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Conta Inexistente!");
                            goto case 2;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("ERRO!");
                            goto case 2;
                        }
                        break;
                    }
                case 3:
                    {
                        try
                        {
                            Console.Write("Digite o CPF do cliente:");
                            string CPF = Console.ReadLine();

                            Cliente findcliente = meusClientes.Find(x => x.getCPF().Equals(CPF));
                            Console.WriteLine(findcliente.ToString());
                           Console.WriteLine("Total Pago em Taxas: R$"+findcliente.totalTaxas().ToString("F2"));
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Valor inserido não é um número válido!");
                            goto case 3;
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("CPF não encontrado!");
                            goto case 3;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("ERRO!");
                            goto case 3;
                        }
                        break;
                    }
                case 4:
                    {
                        contaMaiorSaldo(minhasContas);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Operação inválida");
                        goto inicio;
                    }
            }

        inicio1:
            try
            {

                Console.WriteLine("Digite 1 para voltar ao menu / Digite 2 para sair");
                int escolha = int.Parse(Console.ReadLine());
                if (escolha == 1)
                {
                    Console.Clear();
                    goto inicio;
                }
                else if (escolha == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Você escolheu sair!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Número Inválido!");
                    goto inicio1;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("O valor inserido não é um número inteiro!");
                goto inicio1;
            }
            catch (Exception)
            {
                Console.WriteLine("ERRO!");
                goto inicio1;
            }
        }
        #endregion

        static void Main(string[] args)
        {
            List<Conta> minhasContas = carregarContas();
            carregarOperacoes(minhasContas);
            List<Cliente> meusClientes = carregarClientes(minhasContas);
            Menu(minhasContas,meusClientes);
        }
    }
}
