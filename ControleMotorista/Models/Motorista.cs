using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMotorista.Models
{
    public class Motorista
    {
        public String Nome { get; set; }

        public String CPF { get; set; }

        public String Categoria_CNH { get; set; }

        public String Email { get; set; }

        public DateTime DataNasc { get; set; }

        public String CNH { get; set; }

        public String Realizou_Exame { get; set; }

        public Endereco Endereco { get; set; }
    }
}
