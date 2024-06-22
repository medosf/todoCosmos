using Microsoft.Azure.Cosmos;
using TodoCosmos.Models;
using Newtonsoft.Json;

namespace TodoCosmos.Service;

public class CosmosDbService : ICosmosDbService
{
    private Container _container;

    public CosmosDbService(
        string databaseName,
        string containerName,
        string account,
        string key)
    {
        var client = new CosmosClient(account, key);
        _container = client.GetContainer(databaseName, containerName);
    }

    public async Task<IEnumerable<TodoItem>> GetTodoItemsAsync(string queryString)
    {
        var query = _container.GetItemQueryIterator<TodoItem>(new QueryDefinition(queryString));
        List<TodoItem> results = new List<TodoItem>();
        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            results.AddRange(response.ToList());
        }
        return results;
    }

    public async Task<TodoItem> GetTodoItemAsync(string id)
    {
        try
        {
            ItemResponse<TodoItem> response = await _container.ReadItemAsync<TodoItem>(id, new PartitionKey(id));
            return response.Resource;
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }
    }

    public async Task AddTodoItemAsync(TodoItem item)
    {
    Console.WriteLine($"Item to be added: {JsonConvert.SerializeObject(item)}");

        try {
        await _container.CreateItemAsync(item, new PartitionKey(item.Id));

        }catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.Conflict)
        {
            throw new Exception($"Item with id {item.Id} already exists");
        }

        
    }

    public async Task DeleteTodoItemAsync(string id){

        try{
            await _container.DeleteItemAsync<TodoItem>(id, new PartitionKey(id));

        }catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            throw new Exception($"Item with id {id} not found");
        }
    }



}
