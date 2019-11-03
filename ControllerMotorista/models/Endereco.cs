using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerMotorista.models
{
    public class Endereco
    {
        public String Rua { get; set; }
        public String Numero { get; set; }
        public String Cidade { get; set; }
        public String Bairro { get; set; }
        public int Cep { get; set; }

        public override string ToString()
        {
            return Rua + ", " + Numero + ", " + Bairro + ", " + Cidade + " - " + Cep;
        }
    }
}
