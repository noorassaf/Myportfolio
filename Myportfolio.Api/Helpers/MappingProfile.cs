using AutoMapper;
using Myportfolio.Core.Dtos;
using Myportfolio.Core.Models;


namespace Myportfolio.Api.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<PortfolioItemDto, PortfolioItem>().ForMember(dest=>dest.Id,opt=>opt.Ignore());   
            CreateMap<PortfolioItem,PortfolioItemDetailDto>();
            CreateMap<ApplicationUser,OwnerDto>();

        }
    }
}
