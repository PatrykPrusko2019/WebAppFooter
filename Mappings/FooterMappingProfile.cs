using AutoMapper;
using WebAppFooter.Entities;
using WebAppFooter.Models;

namespace WebAppFooter.Mappings
{
    public class FooterMappingProfile : Profile
    {
        public FooterMappingProfile() 
        {
            CreateMap<Footer, FooterDto>();
            CreateMap<FooterDto, Footer>();
        }
    }
}
