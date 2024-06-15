using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MVC_People.Models.Entity;
using MVC_People.Models.PeopleViewModel;


namespace MVC_People.Models.Interfaces
{
    public interface IPeopleService
    {
        Person Add(CreatePersonViewModel person);
        List<Person> All();
        List<Person> Search(string search);
        Person FindById(int id);
        bool Edit(int id, CreatePersonViewModel person);
        bool Remove(Person person);
       
    }
}


