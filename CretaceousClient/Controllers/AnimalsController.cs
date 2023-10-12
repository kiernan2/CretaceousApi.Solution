using Microsoft.AspNetCore.Mvc;
using CretaceousClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CretaceousClient.Controllers
{
  public class AnimalsController : Controller
  {
    // GET /animals
    public ActionResult Index()
    {
      List<Animal> allAnimals = Animal.GetAnimals();
      return View(allAnimals);
    }

    // Create built into Index view
    [HttpPost, ActionName("Index")]
    public async Task<ActionResult> Create(Animal animal)
    {
      await Animal.Post(animal);
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Animal animal = Animal.GetDetails(id);
      return View(animal);
    }

    public ActionResult Edit(int id)
    {
      Animal animal = Animal.GetDetails(id);
      return View(animal);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(int id, Animal animal)
    {
      animal.AnimalId = id;
      await Animal.Put(animal);
      return RedirectToAction("Details", new { id = id });
    }

    public async Task<ActionResult> Delete(int id)
    {
      await Animal.Delete(id);
      return RedirectToAction("Index");
    }
  }
}
