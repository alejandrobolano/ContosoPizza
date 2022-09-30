using ContosoPizza.Models;

namespace ContosoPizza.Repository.Repository
{
    public static class PizzaDatabase
    {
        public static List<Pizza> GetPizzasDatabase()
        {
            return new List<Pizza>
            {
                new() { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
                new() { Id = 2, Name = "Veggie", IsGlutenFree = true },
                new() { Id = 2, Name = "Veggie Plus", IsGlutenFree = true },
                new() { Id = 3, Name = "Hawaiana", IsGlutenFree = false }
            };
        }


    }
}
