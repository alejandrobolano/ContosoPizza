using ContosoPizza.BusinessLogic.Contracts;
using ContosoPizza.Contracts;
using ContosoPizza.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PizzaController : ControllerBase
{
    private readonly ILogger<PizzaController>? _logger;
    private readonly IPizzaService _pizzaService;
    private readonly string _jsonPath;
    public PizzaController(ILogger<PizzaController> logger, 
        ICustomConfiguration customConfiguration,
        IPizzaService pizzaService)
    {
        _pizzaService = pizzaService;
        _logger = logger;
        _jsonPath = customConfiguration.GetJsonPath();
    }

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll()
    {
        try
        {
           var result = _pizzaService.GetAll();
           return Ok(result);
        }
        catch (Exception exception)
        {
            return BadRequest(exception);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = _pizzaService.Get(id);

        if (pizza == null)
            return NotFound();

        return pizza;
    }

    [HttpPost]
    public IActionResult Add(Pizza pizza)
    {
        var isSuccessful = _pizzaService.Add(pizza, _jsonPath);
        if (isSuccessful)
        {
            return CreatedAtAction(nameof(Add), new { id = pizza.Id }, pizza);
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest();

        var existingPizza = _pizzaService.Get(id);
        if (existingPizza is null)
            return NotFound();

        _pizzaService.Update(pizza);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var pizza = _pizzaService.Get(id);

        if (pizza is null)
            return NotFound();

        _pizzaService.Remove(id);

        return NoContent();
    }

    [HttpGet("{isGlutenFree:bool}")]
    public ActionResult<List<Pizza>> GetAllByGluten(bool isGlutenFree)
    {
        var pizzas = _pizzaService.GetAllByGluten(isGlutenFree).ToList();

        if (pizzas.Count == 0)
        {
            return NotFound();
        }

        return Ok(pizzas);
    }
}