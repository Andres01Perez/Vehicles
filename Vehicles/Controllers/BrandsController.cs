﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehicles.Data;
using Vehicles.DTOs;
using Vehicles.Entities;

namespace Vehicles.Controllers
{
    [ApiController]
    [Route("api/marcas")]
    public class BrandsController : ControllerBase
    {
        private readonly ILogger<BrandsController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BrandsController(ILogger<BrandsController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<BrandDTO>>> GetBrands()
        {
            var brand = await _context.Brands.OrderBy(b => b.nombre).ToListAsync();
            return _mapper.Map<List<BrandDTO>>(brand);
        }

        //Search by parameter
        [HttpGet("{id:int}")]
        public async Task<ActionResult<BrandDTO>> GetBrand(int id)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(v => v.Id == id);

            if (brand == null)
            {
                return NotFound();
            }

            return _mapper.Map<BrandDTO>(brand);
        }

        [HttpPost]
        public async Task<ActionResult<Brand>> PostBrand([FromBody] BrandCreationDTO brandCreationDTO)
        {
            var brand = _mapper.Map<Brand>(brandCreationDTO);

            _context.Add(brand);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Brand>> PutBrand(int id, Brand brand)
        {
            if (id != brand.Id)
            {
                return BadRequest("No coinciden los campos a editar");
            }

            var exist = await _context.Brands.AnyAsync(v => v.Id == id);

            if (!exist)
            {
                return NotFound();
            }

            _context.Update(brand);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            Brand brand = await _context.Brands.FirstOrDefaultAsync(v => v.Id == id);

            if (brand == null)
            {
                return NotFound();
            }

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
