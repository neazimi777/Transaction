using System.Transactions;

namespace teasaction.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async void sum()
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
            {
                try
                {
                    for (int i = 0; i < 100; i++)
                    {
                        var person = _personRepository.Find(1).GetAwaiter().GetResult();
                        person.Count += 1;
                        _personRepository.Update(person);
                        _personRepository.SaveChangeAsync().GetAwaiter().GetResult();
                    }
                    scope.Complete();
                }
                catch (Exception ex) { Console.WriteLine(" ERRRRRRRRRRRRRRRRRor   " + ex.ToString()); }

            }
        }
    }
}
