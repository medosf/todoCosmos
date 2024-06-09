using System.Collections.Generic;
using System.Threading.Tasks;
using TodoComos.Models;

namespace TodoComos.Service;

public interface ICosmosDbService
{
    Task<IEnumerable<TodoItem>> GetTodoItemsAsync(string queryString);
    Task AddTodoItemAsync(TodoItem item);

    Task<TodoItem> GetTodoItemAsync(string id);
}
