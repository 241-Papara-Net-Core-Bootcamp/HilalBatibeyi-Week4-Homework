using AutoMapper;
using Owner.API.Model;
using Owner.Business.Abstract;
using Owner.DataAccess.Abstract;
using Owner.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Owner.Business.Concrete
{
    public class OwnerManager : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerManager(IOwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        private readonly IMapper _mapper;


        public async Task AddAsync(OwnerDto ownertDto)
        {
            var owner = _mapper.Map<OwnerModel>(ownertDto);
            await _ownerRepository.AddAsync(owner);
        }

        public async Task Delete(int id)
        {
            var owner = await _ownerRepository.GetAsync(id);
            await _ownerRepository.DeleteAsync(id);
        }

        public async Task<List<OwnerDto>> GetAllAsync()
        {
            var owner = await _ownerRepository.GetAllAsync();
            var ownerDto = _mapper.Map<List<OwnerDto>>(owner);
            return ownerDto;
        }

        public async Task<OwnerDto> GetAsync(int id)
        {
            var owner = await _ownerRepository.GetAsync(id);
            var ownerDto = _mapper.Map<OwnerDto>(owner);
            return ownerDto;
        }

        public async Task Update(OwnerDto ownerDto, int id)
        {
            var owner = await _ownerRepository.GetAsync(id);
            var result = _mapper.Map<OwnerModel>(ownerDto);
            result.Id = id;
            await _ownerRepository.UpdateAsync(result);
        }
    }
}
