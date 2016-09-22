using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreApiDemo.Models;
using NetCoreApiDemo.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreApiDemo.Controllers
{
  [Route("api/[controller]")]
  public class TodoController : Controller
  {
    private ITodoRepository TodoRepo { get; set; }
    public TodoController(ITodoRepository todoRepo)
    {
      TodoRepo = todoRepo;
    }

    [HttpGet]
    public IEnumerable<TodoItem> GetAll()
    {
      return TodoRepo.GetAll();
    }

    [HttpGet("{id}", Name = "GetTodo")]
    public IActionResult GetById(string id)
    {
      var item = TodoRepo.Find(id);
      if (item == null)
      {
        return NotFound();
      }
      return new ObjectResult(item);
    }

    [HttpPost]
    public IActionResult Create([FromBody] TodoItem item)
    {
      if (item == null)
      {
        return BadRequest();
      }
      TodoRepo.Add(item);
      return CreatedAtRoute("GetTodo", new { id = item.Key }, item);
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] TodoItem item)
    {
      if (item == null || item.Key != id)
      {
        return BadRequest();
      }

      var todo = TodoRepo.Find(id);
      if (todo == null)
      {
        return NotFound();
      }

      TodoRepo.Update(item);
      return new NoContentResult();
    }

    [HttpPatch("{id}")]
    public IActionResult Update([FromBody] TodoItem item, string id)
    {
      if (item == null)
      {
        return BadRequest();
      }

      var todo = TodoRepo.Find(id);
      if (todo == null)
      {
        return NotFound();
      }

      item.Key = todo.Key;

      TodoRepo.Update(item);
      return new NoContentResult();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
      var todo = TodoRepo.Find(id);
      if (todo == null)
      {
        return NotFound();
      }

      TodoRepo.Remove(id);
      return new NoContentResult();
    }
  }
}
