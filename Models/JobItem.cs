namespace TodoComos.Models
{
    public class JobItems    {
  
        public List<JobItem> Jobs { get; set; }

    }

     public class JobItem {
            public string companyName { get; set; }
            public string jobDescription { get; set; }
    }
}