using AutoMapper;
using ComputerBuilder.BL.Model;
using ComputerBuilder.DAL.Entities;


namespace ComputerBuilder.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HardwareItemEntity, HardwareItemModel>();
            // ForMember(i => i.Manufacturer, i => i.MapFrom(m => m.Manufacturer.Name)).
            // ForMember(i => i.PropertyList, i => i.MapFrom(t => t.PropertyList));
            CreateMap<CompatibilityPropertyEntity, CompatibilityPropertyModel>();

            CreateMap<CompatibilityPropertyModel, CompatibilityPropertyEntity>();
        }
    }
}
