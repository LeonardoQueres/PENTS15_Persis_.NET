using Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(36);

            builder.Property(x => x.Logradouro).HasMaxLength(100).IsRequired();

            builder.Property(x => x.Numero);

            builder.Property(x => x.Bairro).HasMaxLength(100).IsRequired();

            builder.Property(x => x.Municipio).HasMaxLength(200).IsRequired();

            builder.Property(x => x.Uf);

            builder.Property(x => x.Cep).HasMaxLength(9);

            builder.Property(x => x.Complemento).HasMaxLength(50);

            builder.Property(x => x.MetadataId).HasMaxLength(36);
        }
    }
}
