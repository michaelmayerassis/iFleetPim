using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloSeguro.Models
{
   public class Seguro
    {
        public string Veiculo_id { get; set; }
        public string Seguradora { get; set; }
        public string Plano { get; set; }
       
        public DateTime Validade { get; set; }

        private Int32 _apolice;
        public int Apolice
        {
            get => _apolice;
            set
            {
                if (isQtdValida(value))
                    _apolice = value;
            }
        }
        private bool isQtdValida(int qtd)
        {
            return qtd >= 0;
        }
    }


}
