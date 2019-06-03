using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControllerMotorista.models
{
    public class Motorista
    {
        public int IdMotorista { get; set; }
        public String Nome { get; set; }

        private string _cpf;
        public String Cpf {
            get { return _cpf; }
            set
            {
                if (IsValid(value))
                    _cpf = value;
                else
                    MessageBox.Show("Digite um CPF válido!", "Alerta", MessageBoxButtons.OK);
            }
        }
        public String Cnh { get; set; }
        public String  CategoriaCnh { get; set; }
        public DateTime DataNascimento { get; set; }
        public String ExameMedico { get; set; }
        public String Email { get; set; }
        public Endereco Endereco { get; set; }


        private static bool IsValid(string cpf)
        {
            return (IsCpf(cpf));
        }

        private static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
