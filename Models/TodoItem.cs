using Newtonsoft.Json;

namespace TodoComos.Models
{
    public class TodoItem
    {
                [JsonProperty(PropertyName = "id")]

        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

    }
}