using ContosoPizza.Models;
using ContosoPizza.Repository.Contracts;
using Newtonsoft.Json;
using System.IO;

namespace ContosoPizza.Repository.Implementations
{
    public class PizzaManageJson : IManageFile<Pizza>
    {
        public bool Add(Pizza item, string path)
        {
            try
            {
                var pizzas = GetAll(path);
                pizzas.Add(item);
                Write(pizzas, path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static string GetJson(string path)
        {
            var json = string.Empty;
            if (File.Exists(path))
            {
                using var jsonStream = File.OpenText(path);
                json = jsonStream.ReadToEnd();
            }
            else
            {
                using var fs = File.Create(path);
                GetJson(path);
            }
            return json;

        }
        public List<Pizza> GetAll(string path)
        {
            var json = GetJson(path);
            return JsonConvert.DeserializeObject<List<Pizza>>(json) ?? new List<Pizza>();
            
        }

        private static void Write(List<Pizza> pizzas, string path)
        {
            var json = JsonConvert.SerializeObject(pizzas, new JsonSerializerSettings());
            File.WriteAllText(path, json);
        }

        public Pizza Get(int id, string path)
        {
            var pizzas = GetAll(path);
            var a = pizzas.FirstOrDefault(pizza => pizza.Id == id);
            return a;
        }
    }
}
