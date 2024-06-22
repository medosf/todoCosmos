using Newtonsoft.Json;

namespace TodoCosmos.Models
{
    public class TodoItem
    {
                [JsonProperty(PropertyName = "id")]

        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

    }
}