using AutoMapper;
using ComputerBuilder.BL.Model;
using ComputerBuilder.DAL.Entities;
using ComputerBuilder.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerBuilder.BL.services
{
    public class HardwareItemService : IHardwareItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HardwareItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddHwItem(HardwareItemModel itemModel)
        {
            var entity = _mapper.Map<HardwareItemEntity>(itemModel);
            var result = await _unitOfWork.HwItems.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return result;
        }

        public async Task<IEnumerable<HardwareItemModel>> GetAllHwItemsFull()
        {
            var entities = await _unitOfWork.HwItems.GetFullHwItemsAsync();
            return _mapper.Map<IEnumerable<HardwareItemModel>>(entities);
        }
    }
}
