using FI.AtividadeEntrevista.DML;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.EntityFrameworkDAL
{
    public class EntrevistaDbContext : DbContext
    {
        public EntrevistaDbContext() : base("BancoDeDados")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beneficiario>()
                .HasKey(k => k.ID);

            modelBuilder.Entity<Beneficiario>()
                .Property(p => p.Nome)
                .HasMaxLength(30);

            modelBuilder.Entity<Beneficiario>()
                .Property(p => p.Cpf)
                .HasMaxLength(11);

            modelBuilder.Entity<Beneficiario>()
                .HasIndex(idx => idx.Cpf)
                .IsUnique();



            modelBuilder.Entity<Beneficiario>()
                .ToTable("BENEFICIARIOS");

            modelBuilder.Entity<Beneficiario>()
                .HasRequired(b => b.ClienteBenficiario)
                .WithMany(b => b.Beneficiarios)
                .HasForeignKey(fk => fk.IDCliente);


        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Beneficiario> Beneficiarios { get; set; }
    }
}
