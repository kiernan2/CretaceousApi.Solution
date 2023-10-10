using Microsoft.AspNetCore.Mvc;
using CretaceousClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CretaceousClient.Controllers
{
  public class AnimalsController : Controller
  {
    public ActionResult Index()
    {
      List<Animal> allAnimals = Animal.GetAnimals();
      return View(allAnimals);
    }
  }
}