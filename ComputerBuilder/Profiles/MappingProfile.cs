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
            CreateMap<CompatibilityPropertyEntity, CompatibilityPropertyModel>();
            CreateMap<ManufacturerEntity, ManufacturerModel>();

            CreateMap<HardwareItemModel, HardwareItemEntity>();
            CreateMap<CompatibilityPropertyModel, CompatibilityPropertyEntity>();
            CreateMap<ManufacturerModel, ManufacturerEntity>();

            CreateMap<string, ManufacturerEntity>().ConvertUsing<StringToManufacturer>();
            CreateMap<string, HardwareTypeEntity>().ConvertUsing<StringToHardwareType>();
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
    }
}
