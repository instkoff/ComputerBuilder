using AutoMapper;
using ComputerBuilder.BL.Model;
using ComputerBuilder.DAL.Entities;
using ComputerBuilder.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuilder.BL.services
{
    public class ComputerBuildService : IComputerBuildService
    {
        private readonly IRepositoryContainer _repositoryContainer;
        private readonly IMapper _mapper;

        public ComputerBuildService(IRepositoryContainer repositoryContainer, IMapper mapper)
        {
            _repositoryContainer = repositoryContainer;
            _mapper = mapper;
        }

        public async Task<int> BuildPcAsync(List<int> hardwareItemIds, string name, string description)
        {
            var pcBuildEntity = new ComputerBuildEntity() { Name = name, Description = description, BuildDate = DateTime.Now };
            foreach (var id in hardwareItemIds)
            {
                var itemEntity = await _repositoryContainer.HwItems.GetByIdAsync(id);
                pcBuildEntity.BuildItems.Add(new ComputerBuildHardwareItem() { ComputerBuildId = pcBuildEntity.Id, HardwareItemId = itemEntity.Id });
                pcBuildEntity.TotalCost += itemEntity.Cost;
            }
            await _repositoryContainer.ComputerBuilds.AddAsync(pcBuildEntity);
            var result = await _repositoryContainer.CommitAsync();
            return result;
        }

        public async Task<IEnumerable<ComputerBuildModel>> GetAllPcAsync()
        {
           var buildsEntities = await _repositoryContainer.ComputerBuilds.GetPcBuilds();
            var buildsModels = _mapper.Map<IEnumerable<ComputerBuildModel>>(buildsEntities);
            return buildsModels;
        }
    }
}
