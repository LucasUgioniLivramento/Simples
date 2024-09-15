using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Visita.Data
{
    public class VisitaContext : DbContext, IUnitOfWork
    {
        public DbSet<Domain.Visita> Visita { get; set; }
        public VisitaContext(DbContextOptions<VisitaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Visita>().ToTable("visita").HasKey(c => c.guid);
            modelBuilder.Entity<Domain.Visita>().ToTable("visita").Property(c => c.guid)
                .IsRequired().HasColumnName("Guid");
        }

        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;
            return sucesso;
        }
    }
}
