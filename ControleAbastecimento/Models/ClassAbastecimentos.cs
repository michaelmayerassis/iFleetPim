using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Pim_ControleFrota
{
    public class ClassAbastecimentos
    {
        public Int32 Codigo { get; set; }
        //public decimal Valor_Unit { get; set; }
        public Double Valor_Total { get; set; }
        //DateTime Data { get; set; }
        public Double KM { get; set; }
        public Double Quant { get; set; }
        public Int32 Codigo_Veiculo { get; set; }
        public String Combustivel { get; set; }
    }

}

