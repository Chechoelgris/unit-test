using ASPTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPTest.Services
{
    public class BeerService : IBeerService
    {
        private List<Beer> _beers = new List<Beer>()
        {
            new Beer(){ Id=1, Name = "Corona", Brand = "Modelo"},
            new Beer(){ Id=2, Name = "Pikantus", Brand = "Erdinger"}

        };

        public IEnumerable<Beer> Get() => _beers;

        public Beer Get(int id) => _beers.FirstOrDefault(x => x.Id == id);
    }
}
