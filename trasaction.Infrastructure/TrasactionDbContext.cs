using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace trasaction.Infrastructure
{
    public class TrasactionDbContext : DbContext, ITrasactionDbContext
    {
        public TrasactionDbContext(DbContextOptions<TrasactionDbContext> options) : base(options)
        {
        }
        public DbSet<Domain.person> person { get; set; }

        public async Task Save()
        {
            await SaveChangesAsync();
        }
    }
}
