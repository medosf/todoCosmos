using Microsoft.AspNetCore.Mvc;
using  TodoComos.Service;
using  TodoComos.Models;

namespace TodoComos.Controllers;

[ApiController]
[Route("todo")]
public class TodoController : ControllerBase
{

    // private readonly ILogger _logger;

    // public TodoController(ILogger logger)
    // {
    //     _logger = logger;
    // }

   private readonly ICosmosDbService _cosmosDbService;

    public TodoController(ICosmosDbService cosmosDbService)
    {
        _cosmosDbService = cosmosDbService;
    }
     [HttpGet]
    public async Task<IActionResult> Get()
    {

        Request.Cookies.TryGetValue("myCookie", out var cookieValue);

        Console.WriteLine($"Cookie Value: {cookieValue}");
        var todos = await _cosmosDbService.GetTodoItemsAsync("SELECT * FROM c");

        return Ok(todos);
    }

    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var todo = await _cosmosDbService.GetTodoItemAsync(id);
        if (todo == null)
        {
            return NotFound();
        }
         // Example of setting a cookie
        var cookieOptions = new CookieOptions
        {
            Path = "/",
            HttpOnly = true,
            Secure = true, 
            Expires = DateTime.UtcNow.AddDays(7) 
        };

        Response.Cookies.Append("testCookie", "testCookieValueInHere", cookieOptions);
        return Ok(todo);
    }
 
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TodoItem item)
    {
        if(item.Id == null || item.Id == string.Empty)
        {
            item.Id = Guid.NewGuid().ToString();
        }

        await _cosmosDbService.AddTodoItemAsync(item);
        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }

}
