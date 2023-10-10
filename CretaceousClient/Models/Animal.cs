using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CretaceousClient.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }

    public static List<Animal> GetAnimals()
    {
      Task<string> apiCallTask = ApiHelper.GetAll();
      string result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Animal> animalList = JsonConvert.DeserializeObject<List<Animal>>(jsonResponse.ToString());

      return animalList;
    }

    public static Animal GetDetails(int id)
    {
      Task<string> apiCallTask = ApiHelper.Get(id);
      string result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Animal animal = JsonConvert.DeserializeObject<Animal>(jsonResponse.ToString());

      return animal;
    }

    public static async Task Post(Animal animal)
    {
      string jsonAnimal = JsonConvert.SerializeObject(animal);
      await ApiHelper.Post(jsonAnimal);
    }

    public static async Task Put(Animal animal)
    {
      string jsonAnimal = JsonConvert.SerializeObject(animal);
      await ApiHelper.Put(animal.AnimalId, jsonAnimal);
    }

    public static async Task Delete(int id)
    {
      await ApiHelper.Delete(id);
    }
  }
}