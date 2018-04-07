using Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class ProcessoConfiguration : IEntityTypeConfiguration<Processo>
    {
        public void Configure(EntityTypeBuilder<Processo> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(36);
            builder.Property(x => x.Numero).HasMaxLength(30);
            builder.Property(x => x.RelatoFiscalizacao).HasMaxLength(1000);
            builder.Property(x => x.Relato);
            builder.Property(x => x.FiscalResponsavel).HasMaxLength(100);

            builder.HasOne(x => x.Fornecedor)
               .WithMany(x => x.Processo)
               .HasForeignKey(x => x.FornecedorId)
               .IsRequired();
        }
    }
}
