using System.Collections.Generic;
using System.Linq;
using MVC_People.Models.Entity;
using MVC_People.Models.Interfaces;

namespace MVC_People.Models.Repositories
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> _people = new List<Person>();
        private static int _idCounter = 1;

        public Person Create(Person person)
        {
            person.Id = _idCounter++;
            _people.Add(person);
            return person;
        }

        public List<Person> Read()
        {
            return _people;
        }

        public Person Read(int id)
        {
            return _people.FirstOrDefault(p => p.Id == id);
        }

        public bool Update(Person person)
        {
            var existingPerson = Read(person.Id);
            if (existingPerson == null)
            {
                return false;
            }

            existingPerson.Name = person.Name;
            existingPerson.PhoneNumber = person.PhoneNumber;
            existingPerson.City = person.City;
            return true;
        }

        public bool Delete(Person person)
        {
            return _people.Remove(person);
        }
    }
}







