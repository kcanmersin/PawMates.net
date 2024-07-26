namespace PawMates.Application.DTOs
{
    public class AdoptionAdDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<PetDto> Pets { get; set; } = new List<PetDto>();
        public bool IsNeutered { get; set; }
        public UserDto User { get; set; }
    }
}
