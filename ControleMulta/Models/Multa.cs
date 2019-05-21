using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMulta.Models
{
  public class Multa
    {
        public int Veiculoid { get; set; }

        public String Cep { get; set; }

        public String Cidade { get; set; }

        public String Estado { get; set; }

        public String Endereco { get; set; }

        public String Gravidade { get; set; }

        public DateTime Data { get; set; }

    }
}
