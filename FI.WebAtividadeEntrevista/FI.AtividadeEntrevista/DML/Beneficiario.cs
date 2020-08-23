using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.DML
{
    public class Beneficiario
    {
        public long ID { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public long IDCliente { get; set; }

        public Cliente ClienteBenficiario { get; set; }

        public Beneficiario()
        {

        }

        public Beneficiario(string cpf, string nome, long iDCliente)
        {
            Cpf = cpf;
            Nome = nome;
            IDCliente = iDCliente;
        }
    }
}
