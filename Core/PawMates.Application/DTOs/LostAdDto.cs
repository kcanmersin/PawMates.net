namespace PawMates.Application.DTOs
{
    public class LostAdDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<PetDto> Pets { get; set; } = new List<PetDto>();
        public string LastSeenLocation { get; set; }
        public DateTime LastSeenTime { get; set; }
        public UserDto User { get; set; }
    }
}
