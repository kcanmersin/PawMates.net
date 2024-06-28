using System.ComponentModel.DataAnnotations;

namespace PawMates.net.Dtos.Ad.Adoption
{
    public class UpdateAdoptionAdRequest : UpdateAdRequest
    {
        public bool IsVaccinated { get; set; }
        [DataType(DataType.Currency)]
        public decimal AdoptionFee { get; set; }
    }
}
