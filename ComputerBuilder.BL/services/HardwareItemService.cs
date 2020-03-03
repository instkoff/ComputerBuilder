using AutoMapper;
using ComputerBuilder.BL.Model;
using ComputerBuilder.DAL.Entities;
using ComputerBuilder.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerBuilder.BL.services
{
    public class HardwareItemService : IHardwareItemService
    {
        private readonly IRepositoryContainer _repositoryContainer;
        private readonly IMapper _mapper;

        private async Task<HardwareItemEntity> HardwareItemEntity(HardwareItemModel itemModel)
        {
            var entity = _mapper.Map<HardwareItemEntity>(itemModel);
            var manufacturerCheck =
                await _repositoryContainer.Manufacturers.SingleOrDefaultAsync(m =>
                    m.Name.ToLower() == itemModel.Manufacturer.ToLower());
            if (manufacturerCheck != null)
            {
                entity.Manufacturer = manufacturerCheck;
            }

            var hardwareTypeCheck =
                await _repositoryContainer.HardwareTypes.SingleOrDefaultAsync(h =>
                    h.Name.ToLower() == itemModel.HardwareType.ToLower());
            if (hardwareTypeCheck != null)
            {
                entity.HardwareType = hardwareTypeCheck;
            }

            foreach (var propertyModel in itemModel.PropertyList)
            {
                var propertyCheck = await _repositoryContainer.CompatibilityPropertyRepository.SingleOrDefaultAsync(p =>
                    p.PropertyName == propertyModel.PropertyName && p.PropertyType == propertyModel.PropertyType);
                if (propertyCheck != null)
                {
                    foreach (var propertyEntity in entity.PropertiesItems)
                    {
                        if (propertyEntity.CompatibilityProperty.PropertyName == propertyCheck.PropertyName &&
                            propertyEntity.CompatibilityProperty.PropertyType == propertyCheck.PropertyType)
                        {
                            propertyEntity.CompatibilityProperty = propertyCheck;
                        }
                    }
                }
            }
            return entity;
        }

        public HardwareItemService(IRepositoryContainer repositoryContainer, IMapper mapper)
        {
            _repositoryContainer = repositoryContainer;
            _mapper = mapper;
        }

        public async Task<int> AddHwItem(HardwareItemModel itemModel)
        {
            var entity = await HardwareItemEntity(itemModel);
            await _repositoryContainer.HwItems.AddAsync(entity);
            var result = await _repositoryContainer.CommitAsync();
            return result;
        }

        public async Task<IEnumerable<HardwareItemModel>> GetAllHwItemsFull()
        {
            var entities = await _repositoryContainer.HwItems.GetFullHwItemsAsync();
            return _mapper.Map<IEnumerable<HardwareItemModel>>(entities);
        }

        public async Task<IEnumerable<HardwareItemModel>> GetFilteredItems(FilterModel filter)
        {
            var entities = await _repositoryContainer.HwItems.GetFullHwItemsAsync();
            if (filter.HardwareTypeCheck == true)
            {
                entities = entities.Where(i => i.HardwareType.Name.ToLower() == filter.HardwareTypeName.ToLower());
            }
            if (filter.ManufacturerCheck == true)
            {
                entities = entities.Where(i => i.Manufacturer.Name.ToLower() == filter.ManufacturerName.ToLower());
            }
            if (filter.HardwarePropertiesCheck == true)
            {
                entities = entities.Where(i =>
                    i.PropertiesItems.Select(p => p.CompatibilityProperty.PropertyType).FirstOrDefault().ToLower() ==
                    filter.HardwareProperties.PropertyType.ToLower());
                entities = entities.Where(i =>
                    i.PropertiesItems.Select(p => p.CompatibilityProperty.PropertyName).FirstOrDefault().ToLower() ==
                    filter.HardwareProperties.PropertyName.ToLower());
            }
            return _mapper.Map<IEnumerable<HardwareItemModel>>(entities);
        }

    }
}
