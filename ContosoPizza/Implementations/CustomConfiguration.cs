using ContosoPizza.Contracts;
using Microsoft.Extensions.Configuration;
namespace ContosoPizza.Implementations
{
    public class CustomConfiguration : ICustomConfiguration
    {
        private readonly IConfiguration _configuration;

        public CustomConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetJsonPath() => _configuration["Configuration:Path"];
    }
}
