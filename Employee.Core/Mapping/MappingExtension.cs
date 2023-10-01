using AutoMapper;
using Employee.Model;
using Employee.Service.Model;

public class MappingExtension : Profile
{
    public MappingExtension()
    {
        CreateMap<VMEmployee, Employees>().ReverseMap()
            .ForMember(x => x.CountryName, x => x.MapFrom(x => x.Country != null? x.Country.CountryName : " "))
            .ForMember(x => x.StateName, x => x.MapFrom(x => x.State != null? x.State.StateName : " "));
        CreateMap<VMCountry, Country>().ReverseMap();
        CreateMap<VMState, State>().ReverseMap()
            .ForMember(x=> x.CountryName, x=> x.MapFrom(x=>x.Country !=null? x.Country.CountryName:" "));
    }

}