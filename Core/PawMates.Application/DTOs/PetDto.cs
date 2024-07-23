namespace PawMates.Application.DTOs
{
    public class PetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Color { get; set; }
    }
}
