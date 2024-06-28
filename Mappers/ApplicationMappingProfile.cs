using AutoMapper;
using PawMates.net.Models;
using PawMates.net.Dtos.Ad;
using PawMates.net.Dtos.Pet;
using PawMates.net.Dtos.Ad.Job;
using PawMates.net.Dtos.Ad.Adoption;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        // Pet mappings
        CreateMap<Pet, PetResponse>();
        CreateMap<CreatePetRequest, Pet>();
        CreateMap<UpdatePetRequest, Pet>();

        // Ad base mappings
        CreateMap<Ad, AdResponse>();
        CreateMap<CreateAdRequest, Ad>();
        CreateMap<UpdateAdRequest, Ad>();

        // JobAd mappings
        CreateMap<JobAd, JobAdResponse>();
        CreateMap<CreateJobAdRequest, JobAd>();
        CreateMap<UpdateJobAdRequest, JobAd>();

        // LostAd mappings
        CreateMap<LostAd, LostAdResponse>();
        CreateMap<CreateLostAdRequest, LostAd>();
        CreateMap<UpdateLostAdRequest, LostAd>();

        // AdoptionAd mappings
        CreateMap<AdoptionAd, AdoptionAdResponse>();
        CreateMap<CreateAdoptionAdRequest, AdoptionAd>();
        CreateMap<UpdateAdoptionAdRequest, AdoptionAd>();
    }
}
