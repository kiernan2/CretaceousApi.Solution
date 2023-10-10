using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CretaceousApi.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
  }
}