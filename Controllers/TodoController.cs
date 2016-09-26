using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[Route("api/[controller]")]
    public class TodoController : Controller
    {
        public TodoController(ITodoRepository todoItems, 
        ILogger<TodoController> logger)
        {
            TodoItems = todoItems;
            _logger = logger;
        }
        public ITodoRepository TodoItems { get; set; }
        private readonly ILogger<TodoController> _logger;

        public IEnumerable<TodoItem> GetAll()
        {
            _logger.LogInformation("Listing all items");
            return TodoItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
              _logger.LogInformation("Getting item {0}", id);
            var item = TodoItems.Find(id);
            if (item == null)
            {
                 _logger.LogWarning("GetById({0}) NOT FOUND", id);
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
            TodoItems.Add(item);
            return CreatedAtRoute("GetTodo", new { id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TodoItem item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var todo = TodoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            TodoItems.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            TodoItems.Remove(id);
        }

        
    }