using ContosoPizza.Models;

namespace ContosoPizza.Contracts
{
    public interface IPizzaService
    {
        public List<Pizza> GetAll();
        public Pizza? Get(int id);
        public void Add(Pizza pizza);
        public void Update(Pizza pizza);
        public void Remove(int id);
        IEnumerable<Pizza> GetAllByGluten(bool isGlutenFree);


    }
}
