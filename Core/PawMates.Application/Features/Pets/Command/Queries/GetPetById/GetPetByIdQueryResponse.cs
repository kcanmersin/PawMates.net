namespace PawMates.Application.Features.Pets.Queries.GetPetById
{
    public class GetPetByIdQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Color { get; set; }
    }
}
