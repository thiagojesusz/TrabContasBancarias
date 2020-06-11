using System;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace ContasBancarias
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Conta cont = new Conta(0001,1, "128.907.506-98", 100),
                  cont1 = new Conta(0002, 0, "128.907.506-98", 100);

            Premium cliente1 = new Premium("128.907.506-98","Thiago");

            cliente1.addConta(cont);
            cliente1.addConta(cont1);
            cont1.saque(110);
            cont.deposito(10);
            Console.WriteLine(cliente1.extrato(0002));*/
            List<Cliente> clientes = new List<Cliente>();
            List<Conta> contas = new List<Conta>();


            using (StreamReader arq = new StreamReader(@"C:\Users\thiag\Desktop\TrabalhoFinal\Dados\dadosClientesPOO.txt")) // dadosClientesPOO
            {
                string reader;

                while (!arq.EndOfStream)
                {
                    reader = arq.ReadLine();
                    string[] pos_arq = reader.Split(';');

                    if (pos_arq[2] == "0")
                    {
                        Regular r = new Regular(pos_arq[0], pos_arq[1]);
                        clientes.Add(r);
                    }

                    else if (pos_arq[2] == "1")
                    {
                        Qualificado q = new Qualificado(pos_arq[0], pos_arq[1]);
                        clientes.Add(q);
                    }

                    else if (pos_arq[2] == "2")
                    {
                        Premium p = new Premium(pos_arq[0], pos_arq[1]);
                        clientes.Add(p);
                    }
                }
            }

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
    }
}
