using System.Collections.Generic;
using System.Threading.Tasks;
using TodoCosmos.Models;

namespace TodoCosmos.Service;

public interface ICosmosDbService
{
    Task<IEnumerable<TodoItem>> GetTodoItemsAsync(string queryString);
    Task AddTodoItemAsync(TodoItem item);

    Task<TodoItem> GetTodoItemAsync(string id);

    Task DeleteTodoItemAsync(string id);
}
