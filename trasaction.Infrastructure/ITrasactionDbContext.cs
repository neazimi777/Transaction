using Microsoft.EntityFrameworkCore;

namespace trasaction.Infrastructure
{
    public interface ITrasactionDbContext
    {
        public DbSet<Domain.person> person { get; set; }
        public  Task Save();
    }
}
