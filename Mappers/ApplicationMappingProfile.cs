using AutoMapper;
using PawMates.net.Dtos.Ad;
using PawMates.net.Dtos.Ad.Adoption;
using PawMates.net.Dtos.Ad.Job;
using PawMates.net.Dtos.Pet;
using PawMates.net.Models;
using System.Linq;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        // Pet mappings
        CreateMap<Pet, PetResponse>();
        CreateMap<CreatePetRequest, Pet>();
        CreateMap<UpdatePetRequest, Pet>();

        // Generic Ad mappings
        CreateMap<Ad, AdResponse>();
        CreateMap<CreateAdRequest, Ad>()
            .ForMember(dest => dest.DatePosted, opt => opt.MapFrom(src => DateTime.UtcNow)); // Assuming ads have a DatePosted property
        CreateMap<UpdateAdRequest, Ad>();

        // Specific Ad Type Mappings
        // Adoption Ads
        CreateMap<AdoptionAd, AdoptionAdResponse>();
        CreateMap<CreateAdoptionAdRequest, AdoptionAd>();
        CreateMap<UpdateAdoptionAdRequest, AdoptionAd>();

        // Job Ads
        CreateMap<JobAd, JobAdResponse>();
        CreateMap<CreateJobAdRequest, JobAd>();
        CreateMap<UpdateJobAdRequest, JobAd>();

        // Lost Ads
        CreateMap<LostAd, LostAdResponse>();
        CreateMap<CreateLostAdRequest, LostAd>();
        CreateMap<UpdateLostAdRequest, LostAd>();

        // for creating pet and ad at the same time
        CreateMap<CreateAdRequest, Ad>()
            .ForMember(dest => dest.DatePosted, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.Pets, opt => opt.MapFrom(src => src.PetDetails));

        // User Mappings (if applicable)
        // CreateMap<AppUser, UserDTO>();  // Assuming a UserDTO exists
        // CreateMap<RegisterDTO, AppUser>(); // Assuming a RegisterDTO exists for registration purposes
        // CreateMap<LoginDTO, AppUser>(); // Assuming a LoginDTO exists for login purposes

        // You can continue adding mappings for other models as necessary
    }
}
