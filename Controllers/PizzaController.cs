using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Controllers;


[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase{
    public PizzaController()
    {
    }

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll(){
        return Ok(PizzaService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id){
        var pizza = PizzaService.Get(id);
        return pizza!=null? Ok(pizza) : NotFound();
    }

    [HttpPost]
    public ActionResult Create(Pizza pizza){
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Create), new {id = pizza.Id}, pizza);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id){
        var pizza = PizzaService.Get(id);
        if(pizza is null){
            return NotFound();
        }
        PizzaService.Update(pizza);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id){
        var pizza = PizzaService.Get(id);
        if(pizza is null){
            return NotFound();
        }
        PizzaService.Delete(id);
        return NoContent();
    }

}