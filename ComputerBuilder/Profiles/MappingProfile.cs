using AutoMapper;
using ComputerBuilder.BL.Model;
using ComputerBuilder.BL.Model.Authorization;
using ComputerBuilder.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ComputerBuilder.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HardwareItemEntity, HardwareItemModel>()
                .ForMember(entity=>entity.PropertyList, opt=>opt
                    .MapFrom(model=>model.PropertiesItems
                        .Select(p=>p.CompatibilityProperty)
                        .ToList()));

            CreateMap<CompatibilityPropertyEntity, CompatibilityPropertyModel>();
            CreateMap<ManufacturerEntity, ManufacturerModel>();
            CreateMap<UserEntity, UserModel>();
            CreateMap<ComputerBuildEntity, ComputerBuildModel>()
                .ForMember(entity=>entity.HardwareItemsList,opt=>opt
                    .MapFrom(model=>model.BuildItems
                    .Select(item=>item.HardwareItem.HardwareType.Name + ": " + item.HardwareItem.Manufacturer.Name + " " + item.HardwareItem.Name + " " + $"({item.HardwareItem.Description})")
                    .ToList()));

            CreateMap<HardwareItemModel, HardwareItemEntity>()
                .ForMember(entity => entity.PropertiesItems, opt => opt
                    .MapFrom(model => model.PropertyList))
                .AfterMap((
                (model, entity) =>
                {
                    foreach (var item in entity.PropertiesItems)
                    {
                        item.HardwareItem = entity;
                    }
                }));

            CreateMap<CompatibilityPropertyModel, CompatibilityPropertyHardwareItem>()
                .ForMember(entity => entity.CompatibilityProperty, opt => opt
                    .MapFrom(model => model));

            CreateMap<CompatibilityPropertyModel, CompatibilityPropertyEntity>();
            CreateMap<ManufacturerModel, ManufacturerEntity>();
            CreateMap<UserModel, UserEntity>();
            CreateMap<ComputerBuildModel, ComputerBuildEntity>();

            CreateMap<string, ManufacturerEntity>()
                .ConvertUsing<StringToManufacturer>();
            CreateMap<string, HardwareTypeEntity>()
                .ConvertUsing<StringToHardwareType>();
        }

        private class StringToManufacturer : ITypeConverter<string, ManufacturerEntity>
        {
            public ManufacturerEntity Convert(string source, ManufacturerEntity destination, ResolutionContext context)
            {
                destination = new ManufacturerEntity(source);
                return destination;
            }
        }
        private class StringToHardwareType : ITypeConverter<string, HardwareTypeEntity>
        {
            public HardwareTypeEntity Convert(string source, HardwareTypeEntity destination, ResolutionContext context)
            {
                destination = new HardwareTypeEntity(source);
                return destination;
            }
        }
    }
}
