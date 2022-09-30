using System.Configuration.Internal;
using ContosoPizza.BusinessLogic.Contracts;
using ContosoPizza.Models;
using ContosoPizza.Repository.Repository;
using ContosoPizza.Repository.Contracts;

namespace ContosoPizza.BusinessLogic.Implementations
{
    public class PizzaService: IPizzaService
    {
        private readonly IManageFile<Pizza> _manageFile;
        public PizzaService(IManageFile<Pizza> manageFile)
        {
            _manageFile = manageFile;
        }
        public List<Pizza> GetAll() => PizzaDatabase.GetPizzasDatabase();

        public Pizza? Get(int id) => PizzaDatabase.GetPizzasDatabase().FirstOrDefault(pizza => pizza.Id == id);

        public bool Add(Pizza pizza, string path)
        {
            //var lastId = GetAll().MaxBy(p => p.Id)?.Id;
            //pizza.Id = lastId + 1 ?? int.MaxValue;
            //GetAll().Add(pizza);
            return _manageFile.Add(pizza, path);
        }
        public void Update(Pizza pizza)
        {
            var index = GetAll().FindIndex(p => p.Id == pizza.Id);
            GetAll()[index] = pizza;
        }

        public void Remove(int id)
        {
            var pizza = Get(id);
            if (pizza != null)
            {
                GetAll().Remove(pizza);
            }
        }

        public IEnumerable<Pizza> GetAllByGluten(bool isGlutenFree) => GetAll().Where(p => p.IsGlutenFree == isGlutenFree);
    }
}
