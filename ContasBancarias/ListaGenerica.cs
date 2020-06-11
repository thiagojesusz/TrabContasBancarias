using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POORestaurante_2020
{
    class ListaGenerica<T> where T: IComparable
    {
        /*
         * 1 - local p/ armazenar dados
         * 2 - inserir
         * 3 - retirar
         * 4 - localizar
         * 5 - imprimir
         * */

        private T[] dados;
        private int quantMax;
        private int quantAtual;
        
        public ListaGenerica(int n)
        {
            if (n >= 2)
            {
                this.dados = new T[n];
                this.quantMax = n;
            }
            else
            {
                this.dados = new T[2];
                this.quantMax = 2;
            }
            this.quantAtual = 0;

        }

        public int quantos() { return quantAtual; }
        public bool inserir(T novo)
        {
            if (quantAtual < quantMax)
            {
                dados[quantAtual] = novo;
                quantAtual++;
                return true;
            }
            else
                return false;
        }

        public T getPos(int i)
        {
            if (i < quantAtual)
                return dados[i];
            else
                return default(T);
        }

        public T localizar(T objetoDeBusca)
        {
            //mecanismo de substituição implícita.
            for(int i=0; i<quantAtual; i++)
            {
                if (dados[i].Equals(objetoDeBusca))
                        return dados[i];
            }
            return default(T);
        }

        public T remover(T objetoDeBusca)
        {
            int pos = -1;
            //mecanismo de substituição implícita.
            for (int i = 0; i < quantAtual; i++)
            {
                if (dados[i].Equals(objetoDeBusca)) {
                    pos =i;
                    break;
                }
            }
            if (pos != -1)
            {
                T aux = dados[pos];
                for(int i= pos; i<quantAtual; i++)
                {
                    dados[i] = dados[i + 1];
                }
                quantAtual--;
                return aux;
            }
            return default(T);
        }
        public T maior()
        {
            T maior = dados[0];
            for (int i = 0; i < quantAtual; i++)
            {
                //CompareTo retorna:
                // -1 se meu objeto for menor
                // 1  se meu objeto for maior
                // 0  se os objetos forem iguais
                if( dados[i].CompareTo(maior) > 0  )
                {
                    maior = dados[i];
                }
            }
            return maior;
        }

        public override string ToString()
        {
            StringBuilder todos = new StringBuilder();

            for (int i = 0; i < quantAtual; i++){
                //mecanismo de substituição implícita.
                todos.AppendLine(dados[i].ToString());
            }

            return todos.ToString();
        }


    }
}


