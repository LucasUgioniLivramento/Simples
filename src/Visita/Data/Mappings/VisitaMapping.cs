using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Visita.Data.Mappings
{
    public class VisitaMapping : IEntityTypeConfiguration<Domain.Visita>
    {
        public void Configure(EntityTypeBuilder<Domain.Visita> builder)
        {
            builder.HasKey(c => c.guid);
            builder.Property(c => c.guid)
                .IsRequired().HasColumnName("guid");
            builder.Property(c => c.cdcliente)
                .IsRequired().HasColumnName("cdcliente");
            builder.Property(c => c.pedidocliguid)
                .IsRequired().HasColumnName("pedidocliguid");
            builder.Property(c => c.cdpedido)
                .IsRequired().HasColumnName("cdpedido");
            builder.Property(c => c.cdsituacaovisita)
                .IsRequired().HasColumnName("cdsituacaovisita");
            builder.Property(c => c.cdvendedor)
                .IsRequired().HasColumnName("cdvendedor");
            builder.Property(c => c.cdvisita)
                .IsRequired().HasColumnName("cdvisita");
            builder.Property(c => c.deobservacao)
                .IsRequired().HasColumnName("deobservacao");
            builder.Property(c => c.dtfim)
                .IsRequired().HasColumnName("dtfim");
            builder.Property(c => c.dtinicio)
                .IsRequired().HasColumnName("dtinicio");
            builder.Property(c => c.flexcluido)
                .IsRequired().HasColumnName("flexcluido");
            builder.Property(c => c.flsituacao)
                .IsRequired().HasColumnName("flsituacao");
            builder.Property(c => c.hrfim)
                .IsRequired().HasColumnName("hrfim");
            builder.Property(c => c.hrinicio)
                .IsRequired().HasColumnName("hrinicio");
            builder.Property(c => c.timestamp)
                .IsRequired().HasColumnName("timestamp");
            builder.Property(c => c.cdempresa)
                .IsRequired().HasColumnName("cdempresa");
            builder.ToTable("visita");
        }
    }
}
