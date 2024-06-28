namespace PawMates.net.Dtos.Ad.Job
{
    public class JobAdResponse : AdResponse
    {
        // public string JobType { get; set; }
        // public string JobDescription { get; set; }
        public string Salary { get; set; }
        public string JobTitle { get; set; }

        public int WorkingHour { get; set; }
    }
}
