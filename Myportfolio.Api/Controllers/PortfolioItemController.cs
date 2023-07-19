using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Myportfolio.Core.Dtos;
using Myportfolio.Core.Models;

namespace Myportfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioItemController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PortfolioItemController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var entity = await _unitOfWork.PortfolioItem.GetAllAsync();

            if (entity is null)
            {
                return NotFound();
            }
         //   var portfolioDetailDto=_mapper.Map<IEnumerable<PortfolioItemDetailDto>>(entity);

            return Ok(entity);
        }
        [HttpGet("GetById{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var entity = await _unitOfWork.PortfolioItem.GetByIdAsync(Id);

            if (entity is null)
            {
                return NotFound();
            }

            return Ok(entity);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(PortfolioItemDto dto)
        {
            if (!ModelState.IsValid)
               return BadRequest(ModelState);

        
            var portfolioItem = _mapper.Map<PortfolioItem>(dto);

            await _unitOfWork.PortfolioItem.AddAsync(portfolioItem);
            _unitOfWork.complet();

            return Ok(portfolioItem);
        }

        [HttpDelete("Delete{Id}")]
        public async Task<IActionResult> Delete(int  Id)
        {
            var PortfolioItem =await _unitOfWork.PortfolioItem.GetByIdAsync(Id);
            if (PortfolioItem ==null) { return NotFound(); }

            _unitOfWork.PortfolioItem.Delete(PortfolioItem);
            _unitOfWork.complet();
            return Ok(PortfolioItem);
        }
        [HttpPut("Update{Id}")]
        public async Task<IActionResult> Update(int Id,PortfolioItemDto dto)
        {
            var PortfolioItem = await _unitOfWork.PortfolioItem.GetByIdAsync(Id);
            if (PortfolioItem is null) return BadRequest();

            PortfolioItem.Description = dto.Description;
            PortfolioItem.ProjectNmae = dto.ProjectNmae;
            PortfolioItem.ProjectUrl = dto.ProjectUrl;
            PortfolioItem.ImageUrl = dto.ImageUrl;


            _unitOfWork.PortfolioItem.Update(PortfolioItem);
            _unitOfWork.complet();
            return Ok(PortfolioItem);
        }
    }
}
