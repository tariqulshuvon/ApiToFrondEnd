using AutoMapper;
using Employee.Model;
using Employee.Service.Model;

public class MappingExtension : Profile
{
    public MappingExtension()
    {
        CreateMap<VMEmployee, Employees>().ReverseMap();
        CreateMap<VMCountry, Country>().ReverseMap();
        CreateMap<VMState, State>().ReverseMap();
    }

}