using AutoMapper;
using Microsoft.AspNetCore.Http;
using PawMates.net.Dtos;
using PawMates.net.Dtos.Ad;
using PawMates.net.Dtos.Ad.Adoption;
using PawMates.net.Dtos.Ad.Job;
using PawMates.net.Dtos.Pet;
using PawMates.net.Models;
using System;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        // Pet mappings
        CreateMap<Pet, PetResponse>();
        CreateMap<CreatePetRequest, Pet>();
        CreateMap<UpdatePetRequest, Pet>();

        // Ad mappings
        CreateMap<CreateAdRequest, Ad>()
            //.ForMember(dest => dest.DatePosted, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.Pet, opt => opt.MapFrom(src => src.PetDetails))
            .ForMember(dest => dest.Images, opt => opt.Ignore()); // Handle images outside of AutoMapper

        CreateMap<UpdateAdRequest, Ad>()
            .ForMember(dest => dest.Pet, opt => opt.MapFrom(src => src.PetDetails))
            .ForMember(dest => dest.Images, opt => opt.Ignore()); // Handle images outside of AutoMapper

        // Job Ad mappings
        CreateMap<CreateJobAdRequest, JobAd>()
            .IncludeBase<CreateAdRequest, Ad>();

        CreateMap<UpdateJobAdRequest, JobAd>()
            .IncludeBase<UpdateAdRequest, Ad>();

        // Adoption Ad mappings
        CreateMap<AdoptionAd, AdoptionAdResponse>();
        CreateMap<CreateAdoptionAdRequest, AdoptionAd>()
            .IncludeBase<CreateAdRequest, Ad>();
        CreateMap<UpdateAdoptionAdRequest, AdoptionAd>()
            .IncludeBase<UpdateAdRequest, Ad>();

        // Lost Ad mappings
        CreateMap<LostAd, LostAdResponse>();
        CreateMap<CreateLostAdRequest, LostAd>()
            .IncludeBase<CreateAdRequest, Ad>();
        CreateMap<UpdateLostAdRequest, LostAd>()
            .IncludeBase<UpdateAdRequest, Ad>();

        // Additional Ad mappings for responses
        CreateMap<Ad, AdResponse>()
            .ForMember(dest => dest.PetDetails, opt => opt.MapFrom(src => src.Pet));

        // Job Ad specific mappings for responses
        CreateMap<JobAd, JobAdResponse>();

        // Image mappings (assuming handling is done prior)
        // CreateMap<Image, ImageDto>(); // Assuming an ImageDto exists for transferring image data

        // User mappings (if applicable)
        // CreateMap<AppUser, UserDTO>(); // Assuming a UserDTO exists
        // CreateMap<RegisterDTO, AppUser>(); // For user registration
        // CreateMap<LoginDTO, AppUser>(); // For user login
    }
}
