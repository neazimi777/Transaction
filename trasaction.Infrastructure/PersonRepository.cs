using Microsoft.EntityFrameworkCore;
using teasaction.Application;
using trasaction.Domain;

namespace trasaction.Infrastructure
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ITrasactionDbContext _trasactionDbContext;
        public PersonRepository(ITrasactionDbContext trasactionDbContext)
        {
            _trasactionDbContext = trasactionDbContext;
        }
        public async Task<person> Find(int id)
        {
            return await _trasactionDbContext.person!.FindAsync(id);

        }

        public person Update(person person)
        {
            return _trasactionDbContext.person.Update(person).Entity;
        }

        public async Task SaveChangeAsync()
        {
            await _trasactionDbContext.Save();
        }
    }
}

    