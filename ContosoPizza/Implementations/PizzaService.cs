using ContosoPizza.Contracts;
using ContosoPizza.Models;
using ContosoPizza.Repository;

namespace ContosoPizza.Implementations
{
    public class PizzaService: IPizzaService
    {
        public List<Pizza> GetAll() => PizzaDatabase.GetPizzasDatabase();

        public Pizza? Get(int id) => PizzaDatabase.GetPizzasDatabase().FirstOrDefault(pizza => pizza.Id == id);

        public void Add(Pizza pizza)
        {
            var lastId = GetAll().MaxBy(p => p.Id)?.Id;
            pizza.Id = lastId + 1 ?? int.MaxValue;
            GetAll().Add(pizza);
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
