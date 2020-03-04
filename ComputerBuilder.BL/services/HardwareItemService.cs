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

        private async Task<HardwareItemEntity> CheckHardwareItemEntityAsync(HardwareItemModel itemModel)
        {
            var entity = _mapper.Map<HardwareItemEntity>(itemModel);

            var manufacturerCheck =
                await _repositoryContainer.Manufacturers
                    .SingleOrDefaultAsync(m => m.Name.ToLower() == itemModel.Manufacturer.ToLower());

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
                    p.PropertyName.ToLower() == propertyModel.PropertyName.ToLower() && p.PropertyType.ToLower() == propertyModel.PropertyType.ToLower());
                if (propertyCheck != null)
                {
                    foreach (var propertyEntity in entity.PropertiesItems)
                    {
                        if (propertyEntity.CompatibilityProperty.PropertyName.ToLower() == propertyCheck.PropertyName.ToLower() &&
                            propertyEntity.CompatibilityProperty.PropertyType.ToLower() == propertyCheck.PropertyType.ToLower())
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

        public async Task<int> RemoveHwItem(int id)
        {
            var entity = await _repositoryContainer.HwItems.GetByIdAsync(id);
            if (entity == null)
                return 0;
            _repositoryContainer.HwItems.Remove(entity);
            var result = await _repositoryContainer.CommitAsync();
            return result;
        }

        public async Task<int> AddHwItem(HardwareItemModel itemModel)
        {
            var entity = await CheckHardwareItemEntityAsync(itemModel);
            await _repositoryContainer.HwItems.AddAsync(entity);
            await _repositoryContainer.CommitAsync();
            return entity.Id;
        }

        public async Task<HardwareItemModel> UpdateHwItemAsync(int id, HardwareItemModel itemModel)
        {

            //ToDo Доработать
            var itemEntityToUpdate = await _repositoryContainer.HwItems.GetFullHwItemByIdAsync(id);

            if (itemEntityToUpdate == null)
                return null;

            itemEntityToUpdate.Name = itemModel.Name;
            itemEntityToUpdate.Cost = itemModel.Cost;
            itemEntityToUpdate.Description = itemModel.Description;

            await _repositoryContainer.CommitAsync();

            var updatedItem = _mapper.Map<HardwareItemModel>(itemEntityToUpdate);
            return updatedItem;
        }

        public async Task<HardwareItemModel> GetHwItemByIdAsync(int id)
        {
            var itemEntity = await _repositoryContainer.HwItems.GetFullHwItemByIdAsync(id);
            if (itemEntity == null)
                return null;
            var itemModel = _mapper.Map<HardwareItemModel>(itemEntity);
            return itemModel;
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
