using ContosoPizza.Contracts;
using ContosoPizza.Implementations;

namespace ContosoPizza
{
    public static class RegisterDependencies
    {
        public static void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPizzaService, PizzaService>();
        }
    }
}
