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

        public HardwareItemService(IRepositoryContainer unitOfWork, IMapper mapper)
        {
            _repositoryContainer = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddHwItem(HardwareItemModel itemModel)
        {
            var entity = _mapper.Map<HardwareItemEntity>(itemModel);
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
            if (filter.HardwareTypeSelect == true)
            {
                entities = entities.Where(i => i.HardwareType.Name.ToLower() == filter.HardwareTypeName.ToLower());
            }
            if (filter.ManufacturerSelect == true)
            {
                entities = entities.Where(i => i.Manufacturer.Name.ToLower() == filter.ManufacturerName.ToLower());
            }
            return _mapper.Map<IEnumerable<HardwareItemModel>>(entities);
        }
    }
}
