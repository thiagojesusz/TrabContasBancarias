using System;
using System.Collections.Generic;
using System.Text;

namespace ContasBancarias
{
    interface ISacavel
    {
        /// <summary>
        /// Métodos que serão implementados nas classes que irão utilizar a interface
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        #region Métodos da Interface
        bool sacar(double valor);
        bool depositar(double valor);
        double rendimento();
        double cobrarTarifa();
        double saldoAtual();
        #endregion
    }
}
