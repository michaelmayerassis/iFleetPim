using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleManutencao.Models
{
    public class FinalizarManutencao
    {
            public int Id { get; set; }
            public string Obs { get; set; }
            public DateTime Data { get; set; }
            public Manutencao Manutencao { get; set; }
            public decimal Valor { get; set; }
    }
}
