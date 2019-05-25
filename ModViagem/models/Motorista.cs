using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModViagem.models
{
    public class Motorista
    {
        public int IdMotorista { get; set; }
        public String Nome { get; set; }
        public String Cpf { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}
