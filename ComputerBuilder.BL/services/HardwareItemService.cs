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
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public HardwareItemService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public HardwareItemModel Get(int id)
        {
            var entity = _repository.Find<HardwareItemEntity>(e => e.Id == id).Include(m => m.Manufacturer).Include(h => h.HardwareType).Include(p => p.PropertyList).Single();
            var model = _mapper.Map<HardwareItemEntity, HardwareItemModel>(entity);
            return model;
        }
        public List<HardwareItemModel> GetAll()
        {
            var entities = _repository.GetAll<HardwareItemEntity>().Include(m=>m.Manufacturer).Include(p=>p.PropertyList).ToList(); 
            var model = _mapper.Map<IList<HardwareItemEntity>,IList<HardwareItemModel>>(entities);
            return model.ToList();
        }
    }
}
