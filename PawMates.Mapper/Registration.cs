using Microsoft.Extensions.DependencyInjection;
using PawMates.Application.Interfaces.AutoMapper;

namespace PawMates.Mapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, AutoMapper.Mapper>();
        }
    }
}
