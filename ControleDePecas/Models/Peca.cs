using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDePecas.Models
{
    public class Peca
    {
        private String _nome;
        public string Nome {
            get => _nome;
            set{
                if (IsNull(value))
                    throw new ArgumentOutOfRangeException("Campo esta vazio");

                _nome = value;
               }
        }

        public int Id { get; set; }

        public string Descricao { get; set; }

        public string Pratileira { get; set; }

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

        private Int32 _qtdMin;
        public int QtdMin {
            get => _qtdMin;
            set
            {
                if (isQtdValida(value))
                    _qtdMin = value;
            }
        }

        private Decimal _valor;
        public decimal Valor {
            get => _valor;
            set
            {
                if (isValorValida(value))
                    _valor = value;
            }
        }

        private bool isQtdValida(int qtd)
        {
            return qtd >= 0;
        }

        private bool isValorValida(decimal qtd)
        {
            return qtd > 0;
        }

        private bool IsNull(String field) => field == string.Empty;
    }
}
