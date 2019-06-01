using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleManutencao
{
    public class Manutencao
    { 
        public int Veiculo_Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataPrevista { get; set; }
    }
}
