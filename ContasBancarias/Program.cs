using System;

namespace ContasBancarias
{
    class Program
    {
        static void Main(string[] args)
        {
            Conta cont = new Conta(0001, "Thiago", 100,1);
            Premium cliente1 = new Premium("128.907.506-98","Thiago");

            cont.saque(20);
            cont.deposito(10);
            Console.WriteLine(cliente1.extrato(0001));
        }
    }
}
