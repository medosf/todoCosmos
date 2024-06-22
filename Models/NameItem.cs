
namespace TodoCosmos.Models
{
    public class NameItem {
        public string Name {get; set;}

        public List<countryItem> Country {get; set;}

    }
}

public class countryItem {
    public string Country_id {get; set;}
    public float Probability {get; set;}

    public string ProbabilityPercentage => (Probability * 100).ToString("0.00") + "%";
}
