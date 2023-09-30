using trasaction.Domain;

namespace teasaction.Application
{
    public interface IPersonRepository
    {
        public Task<person> Find(int id);
        public person Update(person person);
        public Task SaveChangeAsync();
    }
}
