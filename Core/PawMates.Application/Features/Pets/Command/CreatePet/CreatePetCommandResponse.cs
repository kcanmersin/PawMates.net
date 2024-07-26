namespace PawMates.Application.Features.Pets.Command.CreatePet
{
    public class CreatePetCommandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Color { get; set; }
    }
}
