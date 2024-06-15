using System.Collections.Generic;
using MVC_People.Models.Entity;

namespace MVC_People.Models.Interfaces
{
    public interface IPeopleRepo
    {
        Person Create(Person person);
        List<Person> Read();
        Person Read(int id);
        bool Update(Person person);
        bool Delete(Person person);
    }
}





