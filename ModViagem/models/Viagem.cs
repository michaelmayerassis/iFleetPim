using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModViagem.models
{
    public class Viagem
    {
        private DateTime _dataEntrada;
        public DateTime DataEntrada
        {
            get => _dataEntrada;

            set
            {
                if (DateTime.Compare(value, DateTime.Now) < 0)
                {
                    _dataEntrada = value;
                }
            }
        }

        public int IdVeiculo { get; set; }
        public String NomeVeiculo { get; set; }
        public String PlacaVeiculo { get; set; }

        public DateTime DataSaida { get; set; }

        public String Local { get; set; }

        public Decimal KmEntrada { get; set; }
        public Decimal KmSaida { get; set; }

 
    }
}
