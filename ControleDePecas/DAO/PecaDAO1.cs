using ControleDePecas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDePecas.DAO
{
    public class PecaDAO1
    {
        public List<Peca1> Pecas;

        public PecaDAO1()
        {
            Pecas = new List<Peca1>();
        }

        public void Adicionar(Peca1 pecas)
        {
            Pecas.Add(pecas);
        }

        public List<Peca1> FindAll()
        {
            return Pecas;
        }
    }
}
