using _01_Mapping.DirectMapping.Models;
using _01_Mapping.DirectMapping.Models.Entitites;
using AutoMapper;

namespace _01_Mapping.AutoMapper.Profiles;

public class AutoMapperProfile
{
    public MapperConfiguration Configuration { get; set; }

	public AutoMapperProfile()
	{
		Configuration = new MapperConfiguration(x =>
		{
			x.CreateMap<CustomerEntity, Customer>()
				.ForMember(des => des.CustomerId, x => x.MapFrom(src => src.Id))
				.ForMember(des => des.FirstName, x => x.MapFrom(src => src.FirstName))
				.ForMember(des => des.LastName, x => x.MapFrom(src => src.LastName))
				.ForMember(des => des.EmailAddress, x => x.MapFrom(src => src.Email));

            x.CreateMap<Customer,  CustomerEntity>()
                .ForMember(des => des.Id, x => x.MapFrom(src => src.CustomerId))
                .ForMember(des => des.FirstName, x => x.MapFrom(src => src.FirstName))
                .ForMember(des => des.LastName, x => x.MapFrom(src => src.LastName))
                .ForMember(des => des.Email, x => x.MapFrom(src => src.EmailAddress));
		});
	}
}
