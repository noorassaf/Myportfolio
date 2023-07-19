using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Myportfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OwnersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet("Getinfo{Id}")]
        public async Task<IActionResult> GeT(int Id)
        {
            var entity = await _unitOfWork.Owner.GetInfo(Id);

            if (entity is null)
            {
                return NotFound();
            }
            var owner = _mapper.Map<OwnerDto>(entity);
            return Ok(owner);
        }
    }
} 
