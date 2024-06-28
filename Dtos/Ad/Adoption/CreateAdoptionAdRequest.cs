using System.ComponentModel.DataAnnotations;

namespace PawMates.net.Dtos.Ad.Adoption
{
    public class CreateAdoptionAdRequest : CreateAdRequest
    {
        [Required]
        public bool IsVaccinated { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal AdoptionFee { get; set; }
    }
}
