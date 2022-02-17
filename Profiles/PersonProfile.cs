using AutoMapper;
using SchemaFirst.Data;

namespace SchemaFirst.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            this.CreateMap<Person, DTOs.PersonDto>()
                .ForMember(x => x.IdDto, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.NameDto, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.LastNameDto, x => x.MapFrom(y => y.LastName))
                .ForAllMembers(x => x.ExplicitExpansion());
        }
    }
}
