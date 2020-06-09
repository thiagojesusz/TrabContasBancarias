using System;

namespace ContasBancarias
{
    class Program
    {
        static void Main(string[] args)
        {
            Conta cont = new Conta(0001,1, "128.907.506-98", 100),
                  cont1 = new Conta(0002, 0, "128.907.506-98", 200);

            Premium cliente1 = new Premium("128.907.506-98","Thiago");

            cliente1.addConta(cont);
            cliente1.addConta(cont1);
            cont.saque(20);
            cont.deposito(10);
            Console.WriteLine(cliente1.extrato(0001));
        }
    }
}
