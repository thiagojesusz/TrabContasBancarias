using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    interface ISacavel
    {
        bool sacar(double valor);
        bool depositar(double valor);
        double rendimento();
        double cobrarTarifa();
        double saldoAtual();
    }
}
