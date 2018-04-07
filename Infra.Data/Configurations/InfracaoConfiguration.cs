using Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class InfracaoConfiguration : IEntityTypeConfiguration<Infracao>
    {
        public void Configure(EntityTypeBuilder<Infracao> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(36);
            builder.Property(x => x.Gravidade);
            builder.Property(x => x.Atenuante);
            builder.Property(x => x.Agravante);
            builder.Property(x => x.Multa);

            builder.HasOne(x => x.Processo)
               .WithMany(x => x.Infracao)
               .HasForeignKey(x => x.ProcessoId)
               .IsRequired();
        }
    }
}
