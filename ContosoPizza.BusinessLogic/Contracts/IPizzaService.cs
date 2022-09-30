using ContosoPizza.Models;

namespace ContosoPizza.BusinessLogic.Contracts
{
    public interface IPizzaService
    {
        public List<Pizza> GetAll();
        public Pizza? Get(int id);
        public bool Add(Pizza pizza, string path);
        public void Update(Pizza pizza);
        public void Remove(int id);
        IEnumerable<Pizza> GetAllByGluten(bool isGlutenFree);


    }
}
