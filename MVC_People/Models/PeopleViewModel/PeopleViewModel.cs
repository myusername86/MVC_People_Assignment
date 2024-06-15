using MVC_People.Models.Entity;

namespace MVC_People.Models.PeopleViewModel
{
    public class PeopleViewModel
    {
        public string search { get; set; }

        public List<Person>People { get; set; } 
    }
}
