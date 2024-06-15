using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_People.Models;
using MVC_People.Models.Entity;
using MVC_People.Models.Interfaces;
using MVC_People.Models.PeopleViewModel;
using MVC_People.Models.Repositories;
using MVC_People.Models.Services;



public class PeopleController : Controller
{
    private readonly IPeopleService _peopleService;

    public PeopleController()
    {
        _peopleService = new PeopleService(new InMemoryPeopleRepo());
    }

    public IActionResult Index(string searchTerm)
    {
        var peopleViewModel = new PeopleViewModel
        {
            People = _peopleService.Search(searchTerm),
            search = searchTerm
        };

        return View(peopleViewModel);
    }

    public IActionResult Details(int id)
    {
        var person = _peopleService.FindById(id);
        if (person == null)
        {
            return NotFound();
        }

        return View(person);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CreatePersonViewModel model)
    {
        if (ModelState.IsValid)
        {
            _peopleService.Add(model);
            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var person= _peopleService.FindById(id);
    
        if (person == null)
        {
            return NotFound();
}
        var model = new CreatePersonViewModel
        {
            Name = person.Name,
            PhoneNumber = person.PhoneNumber,
            City = person.City
        };
        return View(model);
        }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id,CreatePersonViewModel model)
    {
        if(ModelState.IsValid) {
        var update=_peopleService.Edit(id,model);
            if(update)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", "failed to update the person");
        }
        return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
public IActionResult Delete(string name,int phoneNumber,string city)
    {
        var person = _peopleService.All().FirstOrDefault(p => p.Name == name && p.PhoneNumber == phoneNumber && p.City == city);
        if (person == null)
        {
            return NotFound();
        }
        var removed=_peopleService.Remove(person);
        if(!removed)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Index));
    }

    //[HttpPost, ActionName("Delete")]
    //[ValidateAntiForgeryToken]
    //public IActionResult DeleteConfirmed(int id)
    //{
    //    _peopleService.Remove(id);
    //    return RedirectToAction(nameof(Index));
    //}
    
}
