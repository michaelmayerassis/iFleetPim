using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Pim_ControleFrota
{
    public class ClassVeiculos
    {
        public Int32 Codigo { get; set; }
        public Int32 Empresa_Id;
        public String Nome { get; set; }
        public String Cor { get; set; }
        public String Modelo { get; set; }
        public Int32 Ano { get; set; }
        public String Placa { get; set; }
        public String Renavan { get; set; }
        public String Marca { get; set; }
        /*public DateTime dt_UltimaManutencao { get; set; }
        public String disponibilidade { get; set; }*/
        


    }
}
