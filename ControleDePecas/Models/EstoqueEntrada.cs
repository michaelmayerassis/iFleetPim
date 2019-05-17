using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDePecas.Models
{
    public class EstoqueEntrada
    {
        public DateTime Data { get; set; }

        private Int32 _qtdEstoque;
        public int QtdEstoque
        {
            get => _qtdEstoque;
            set
            {
                if (isQtdValida(value))
                    _qtdEstoque = value;
            }
        }

        private Int32 _idPeca;
        public int IdPeca
        {
            get => _idPeca;
            set
            {
                if (isQtdValida(value))
                    _idPeca = value;
            }
        }

        private bool isQtdValida(int qtd)
        {
            return qtd >= 0;
        }
    }
}
