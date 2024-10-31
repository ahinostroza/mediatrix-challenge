namespace SB.TechnicalChallenge.Application;
using AutoMapper;
using SB.TechnicalChallenge.Domain;

public class ProfileMapping : Profile
{
    public ProfileMapping()
    {
        CreateMap<Organism, OrganismViewModel>()
               .ForMember(t => t.Id, o => o.MapFrom(t => t.Id))
               .ForMember(t => t.Name, o => o.MapFrom(t => t.Name))
               .ForMember(t => t.IsActive, o => o.MapFrom(t => t.IsActive))
               .ReverseMap();
    }
}
