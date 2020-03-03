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
            CreateMap<HardwareItemEntity, HardwareItemModel>();
            CreateMap<CompatibilityPropertyEntity, CompatibilityPropertyModel>();
            CreateMap<ManufacturerEntity, ManufacturerModel>();
            CreateMap<UserEntity, UserModel>();
            CreateMap<ComputerBuildEntity, ComputerBuildModel>().ForMember(c=>c.HardwareItemsList,c=>c.MapFrom(i=>i.BuildItems.
                Select(h=>h.HardwareItem.HardwareType.Name + ": " + h.HardwareItem.Manufacturer.Name + " " + h.HardwareItem.Name + " " + $"({h.HardwareItem.Description})").
                ToList()));

            CreateMap<HardwareItemModel, HardwareItemEntity>();
            CreateMap<CompatibilityPropertyModel, CompatibilityPropertyEntity>();
            CreateMap<ManufacturerModel, ManufacturerEntity>();
            CreateMap<UserModel, UserEntity>();
            CreateMap<ComputerBuildModel, ComputerBuildEntity>();

            CreateMap<string, ManufacturerEntity>().ConvertUsing<StringToManufacturer>();
            CreateMap<string, HardwareTypeEntity>().ConvertUsing<StringToHardwareType>();
        }

        public class StringToManufacturer : ITypeConverter<string, ManufacturerEntity>
        {
            public ManufacturerEntity Convert(string source, ManufacturerEntity destination, ResolutionContext context)
            {
                destination = new ManufacturerEntity(source);
                return destination;
            }
        }
        public class StringToHardwareType : ITypeConverter<string, HardwareTypeEntity>
        {
            public HardwareTypeEntity Convert(string source, HardwareTypeEntity destination, ResolutionContext context)
            {
                destination = new HardwareTypeEntity(source);
                return destination;
            }
        }
    }
}
