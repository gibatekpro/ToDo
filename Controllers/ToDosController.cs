using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Models;
using ToDo.Services;

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly ToDoContext _context;

        //ILogger, for logging
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IToDoService _toDoService;

        public ToDosController(ToDoContext context, ILogger<ToDosController> logger, IMapper mapper,
            IToDoService toDoService)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _toDoService = toDoService;
        }

        // GET: api/ToDos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetToDoItems()
        {
            try
            {
                var todoResponses = await _toDoService.FetchToDoList();
                return Ok(todoResponses);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while fetching ToDo items.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // GET: api/ToDos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoResponse>> GetToDoItem(long id)
        {
            try
            {
                var todoResponse = await _toDoService.FetchToDoItem(id);
                return Ok(todoResponse);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while fetching ToDo item.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // PUT: api/ToDos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoItem(long id, ToDoItem toDoItem)
        {
            try
            {
                await _toDoService.UpdateToDoItem(id, toDoItem);
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while fetching ToDo item.");
                return StatusCode(500, "An error occurred while processing your request.");
            }

        }

        // POST: api/ToDos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ToDoResponse>> PostToDoItem(ToDoItem toDoItem)
        {

            try
            {
                var toDoResponse = await _toDoService.PostToDoItem(toDoItem);
                
                return CreatedAtAction("GetToDoItem", new { id = toDoResponse.Id }, toDoResponse);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while posting the ToDo item.");
                throw;
            }
        }

        // DELETE: api/ToDos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItem(long id)
        {
            try
            {
                await _toDoService.DeleteToDoItem(id);
                return NoContent();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message); //Return 404 if the item is not found
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while deleting the ToDo item with ID {Id}.", id);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // GET: api/fetch-store-todos
        [HttpGet("fetch-store-todos")]
        public async Task<IActionResult> FetchAndStoreToDos()
        {
            _logger.LogInformation("Fetching and storing ToDos process started.");

            try
            {
                await _toDoService.FetchAndStoreToDos();
                _logger.LogInformation("ToDos fetched and stored successfully.");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while fetching and storing ToDos.");
                return StatusCode(500, "An error occurred while processing the request.");
            }

            return Ok("Data fetched and saved successfully.");
        }
        
        // GET: api/search
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ToDoResponse>>> SearchToDoItems(string? title, int? priority, DateTime? dueDate)
        {
            try
            {
                var results = await _toDoService.SearchToDoItems(title, priority, dueDate);
                return Ok(results);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while searching To-Do items.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}