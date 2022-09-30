using ContosoPizza.BusinessLogic.Contracts;
using ContosoPizza.BusinessLogic.Implementations;
using ContosoPizza.Contracts;
using ContosoPizza.Implementations;
using ContosoPizza.Models;
using ContosoPizza.Repository.Contracts;
using ContosoPizza.Repository.Implementations;

namespace ContosoPizza
{
    public static class RegisterDependencies
    {
        public static void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICustomConfiguration, CustomConfiguration>();
            serviceCollection.AddScoped<IPizzaService, PizzaService>();
            serviceCollection.AddScoped<IManageFile<Pizza>, PizzaManageJson>();
        }
    }
}
