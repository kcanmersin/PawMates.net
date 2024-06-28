using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PawMates.net.Dtos.Ad.Job;

namespace PawMates.net.Interfaces
{
    public interface IJobAdRepository
    {
        Task<List<JobAdResponse>> GetAllAsync();
        Task<JobAdResponse?> GetByIdAsync(int id);
        Task<JobAdResponse> CreateAsync(CreateJobAdRequest jobAdDto);
        Task<JobAdResponse?> UpdateAsync(int id, UpdateJobAdRequest jobAdDto);
        Task<JobAdResponse?> DeleteAsync(int id);
    }
}
