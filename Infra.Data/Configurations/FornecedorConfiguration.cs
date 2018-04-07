using Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Infra.Data.Configurations
{
    [ExcludeFromCodeCoverage]

    public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
    {
        void IEntityTypeConfiguration<Fornecedor>.Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(36);

            builder.Property(x => x.Cnpj).HasMaxLength(14);
            builder.Property(x => x.RazaoSocial).HasMaxLength(200);
            builder.Property(x => x.InscricaoMunicipal).HasMaxLength(8);
            builder.Property(x => x.ReceitaBruta);

            builder.Ignore(x => x.Enderecos);

        }
    }
}
