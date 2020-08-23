using FI.AtividadeEntrevista.DML;
using Infraestrutura.EntityFrameworkDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorios
{
    public class EntrevistaRepositorio
    {
        EntrevistaDbContext context;

        public EntrevistaRepositorio()
        {
            this.context = new EntrevistaDbContext();
        }

        public void Adicionar(Beneficiario beneficiario)
        {
            context.Beneficiarios.Add(beneficiario);
            context.SaveChanges();
        }

        public IEnumerable<Beneficiario> ListarBeneficiarios()
        {
            return context.Beneficiarios;
        }

        public Beneficiario ObterBeneficiario(int id)
        {
            return context.Beneficiarios.Where(b => b.ID == id).FirstOrDefault();
        }

        public void Apagar(Beneficiario beneficiario)
        {
            context.Beneficiarios.Remove(beneficiario);
            context.SaveChanges();
        }
    }
}
