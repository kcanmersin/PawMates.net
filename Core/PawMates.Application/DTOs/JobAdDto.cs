namespace PawMates.Application.DTOs
{
    public class JobAdDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<PetDto> Pets { get; set; } = new List<PetDto>();
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }
        public bool IsFullTime { get; set; }
        public UserDto User { get; set; }
    }
}
