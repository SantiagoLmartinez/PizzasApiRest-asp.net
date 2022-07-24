using newFolder.Models;
using newFolder.Services;
using Microsoft.AspNetCore.Mvc;


namespace newFolder.Controllers;
[ApiController]
[Route("[controller]")]

public class PizzaController : ControllerBase
{
    public PizzaController()
    {

    }
    //GetAll
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

    //GetById
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);
        if (pizza == null)
            return NotFound();

        return pizza;
    }
    //POST ACTION
    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);  
    }
    //PUT ACTION
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if(id != pizza.Id)
            return BadRequest();

        var existingPizza= PizzaService.Get(id);
        if (existingPizza == null)
            return NotFound();

        PizzaService.Update(pizza);
        return NoContent();
    }
 
    //DELETE ACTION
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = PizzaService.Get(id);
        if (pizza is null)
            return NotFound();
        PizzaService.Delete(id);
        return NoContent();
    }
}
