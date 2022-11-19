using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Owner.API.Data;
using Owner.API.Model;
using Owner.Business.Abstract;
using Owner.Entities.DTOs;
using System.Threading.Tasks;

namespace Owner.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _ownerService.GetAllAsync();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _ownerService.GetAsync(id);
            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> Add(OwnerDto ownerDto)
        {
            await _ownerService.AddAsync(ownerDto);
            return Ok();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(OwnerDto ownerDto, int id)
        {

            await _ownerService.Update(ownerDto, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ownerService.Delete(id);
            return Ok();
        }
    }
}
