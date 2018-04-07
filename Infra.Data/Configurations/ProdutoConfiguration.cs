using Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(36);

            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Marca).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Estoque).HasMaxLength(100).IsRequired();

            builder.HasOne(x => x.Fornecedor)
               .WithMany(x => x.Produto)
               .HasForeignKey(x => x.FornecedorId)
               .IsRequired();
        }
    }
}
