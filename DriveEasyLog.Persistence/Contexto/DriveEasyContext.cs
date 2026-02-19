using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Domain;
using Microsoft.EntityFrameworkCore;


namespace DriveEasyLog.Persistence.Contexto
{
    public class DriveEasyContext:DbContext
    {
        public DriveEasyContext(DbContextOptions<DriveEasyContext> options) : base(options){}
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Responsavel> Responsaveis { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Viagem> Viagens { get; set; }
        public DbSet<PresencaDiaria> Presencas { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1. Relacionamento 1:1 - Motorista e Veículo
             modelBuilder.Entity<Motorista>()
            .HasOne(m => m.Veiculo)
            .WithOne(v => v.Motorista)
            .HasForeignKey<Veiculo>(v => v.MotoristaId);

            // 2. Relacionamento 1:N - Motorista e Alunos
            modelBuilder.Entity<Aluno>()
            .HasOne(a => a.Motorista)
            .WithMany(m => m.Alunos)
            .HasForeignKey(a => a.MotoristaId);

            // 3. Relacionamento 1:N - Responsável e Alunos (Filhos)
            modelBuilder.Entity<Aluno>()
            .HasOne(a => a.Responsavel)
            .WithMany(r => r.Alunos)
            .HasForeignKey(a => a.ResponsavelId);

            // 4. Relacionamento 1:N - Escola e Alunos
            modelBuilder.Entity<Aluno>()
            .HasOne(a => a.Escola)
            .WithMany(e => e.Alunos)
            .HasForeignKey(a => a.EscolaId);

            //modelBuilder.Ignore<Periodo>();
}
    
    }
}