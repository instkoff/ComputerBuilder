using AutoMapper;
using ComputerBuilder.BL.Model;
using ComputerBuilder.BL.Model.Authorization;
using ComputerBuilder.DAL.Entities;
using System.Collections.Generic;

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
            CreateMap<ComputerBuildEntity, ComputerBuildModel>();

            CreateMap<HardwareItemModel, HardwareItemEntity>();
            CreateMap<CompatibilityPropertyModel, CompatibilityPropertyEntity>();
            CreateMap<ManufacturerModel, ManufacturerEntity>();
            CreateMap<UserModel, UserEntity>();
            CreateMap<ComputerBuildModel, ComputerBuildEntity>();

            CreateMap<string, ManufacturerEntity>().ConvertUsing<StringToManufacturer>();
            CreateMap<string, HardwareTypeEntity>().ConvertUsing<StringToHardwareType>();
            CreateMap<ComputerBuildHardwareItem, List<HardwareItemModel>>().ConvertUsing<ComputerBuildHardwareItemToListHwItems>();
        }

        public class StringToManufacturer : ITypeConverter<string, ManufacturerEntity>
        {
            public ManufacturerEntity Convert(string source, ManufacturerEntity destination, ResolutionContext context)
            {
                var manufacturer = new ManufacturerEntity(source);
                return manufacturer;
            }
        }
        public class StringToHardwareType : ITypeConverter<string, HardwareTypeEntity>
        {
            public HardwareTypeEntity Convert(string source, HardwareTypeEntity destination, ResolutionContext context)
            {
                var hardwareType = new HardwareTypeEntity(source);
                return hardwareType;
            }
        }
        public class ComputerBuildHardwareItemToListHwItems : ITypeConverter<ComputerBuildHardwareItem, List<HardwareItemModel>>
        {
            public List<HardwareItemModel> Convert(ComputerBuildHardwareItem source, List<HardwareItemModel> destination, ResolutionContext context)
            {
                destination.Add(source.HardwareItem);
            }
        }
    }
}
