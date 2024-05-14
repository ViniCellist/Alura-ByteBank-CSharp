using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank_ATENDIMENTO.bytebank.Util
{
    public class ListaDeContasCorrentes
    {
        private ContaCorrente[] _itens = null;
        private int _proximaPosicao = 0;

        public ListaDeContasCorrentes(int tamanhoInicial = 5)
        {
            _itens = new ContaCorrente[tamanhoInicial];
        }
    }

    public void Adicionar(ListaDeContasCorrentes item)
    {
        Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");
        _itens[_proximaPosicao] = item;
        _proximaPosicao++;
    }
}