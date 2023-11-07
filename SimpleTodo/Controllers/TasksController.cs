using Microsoft.AspNetCore.Mvc;
using SimpleTodo.Entities.Requests;
using SimpleTodo.Entities.Responses;
using SimpleTodo.Persistence;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleTodo.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        // GET: api/<TasksController>
        [HttpGet]
        public IActionResult Get()
        {
            if (TasksList.Any() == false)
                return NoContent();

            return Ok(TasksList.GetAll());
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var task= TasksList.GetTask(id);
            if (task == null) return NotFound();   
            return Ok(task);
        }

        // POST api/<TasksController>
        [HttpPost]
        public IActionResult Post([FromBody] SaveTask newTask)
        {
            if (ModelState.IsValid == false) return ValidationProblem(ModelState);
            var task = new TodoTask(newTask.Description);
            TasksList.Add(task);
            return Ok(task);
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SaveTask newValues)
        {
            if (ModelState.IsValid == false) return ValidationProblem(ModelState);
            var resTask= TasksList.Edit(id, newValues);
            if (resTask == null)
                return NotFound();
            return Ok(resTask);
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(TasksList.Delete(id) == false) return NotFound();
            return Ok();
        }
    }
}
