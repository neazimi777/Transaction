// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using teasaction.Application;
using teasaction.Application.Services;
using trasaction.Infrastructure;


var services = new ServiceCollection();

services.AddDbContext<TrasactionDbContext>(options =>
              options.UseSqlServer(
                 "Server=.;Database=test;Trusted_Connection=True;"));
services.AddScoped<ITrasactionDbContext, TrasactionDbContext>();
services.AddScoped<IPersonRepository, PersonRepository>();
services.AddScoped<IPersonService, PersonService>();

var _personService = services.BuildServiceProvider().GetService<IPersonService>();

//_personService.sum();


//Console.WriteLine("hiiiiiiiiiiii finishe");

Thread t1 = new Thread(_personService.sum)
{
    Name = "Thread1"
};
Thread t2 = new Thread(_personService.sum)
{
    Name = "Thread2"
};
Thread t3 = new Thread(_personService.sum)
{
    Name = "Thread3"
};
t1.Start();
t2.Start();
//t3.Start();



