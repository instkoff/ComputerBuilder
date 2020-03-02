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

        public HardwareItemService(IRepositoryContainer repositoryContainer, IMapper mapper)
        {
            _repositoryContainer = repositoryContainer;
            _mapper = mapper;
        }

        public async Task<int> AddHwItem(HardwareItemModel itemModel)
        {
            var entity = _mapper.Map<HardwareItemEntity>(itemModel);
            var manufacturerCheck = await _repositoryContainer.Manufacturers.SingleOrDefaultAsync(m => m.Name.ToLower() == itemModel.Manufacturer.ToLower());
            if (manufacturerCheck != null)
            {
                entity.Manufacturer = manufacturerCheck;
            }
            var hardwareTypeCheck = await _repositoryContainer.HardwareTypes.SingleOrDefaultAsync(h => h.Name.ToLower() == itemModel.HardwareType.ToLower());
            if (hardwareTypeCheck != null)
            {
                entity.HardwareType = hardwareTypeCheck;
            }
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
                entities = entities.Where(i => i.PropertyList.Select(p => p.PropertyType).FirstOrDefault().ToLower() == filter.HardwareProperties.PropertyType.ToLower());
                entities = entities.Where(i => i.PropertyList.Select(p=>p.PropertyName).FirstOrDefault().ToLower() == filter.HardwareProperties.PropertyName.ToLower());
            }
            return _mapper.Map<IEnumerable<HardwareItemModel>>(entities);
        }
    }
}
