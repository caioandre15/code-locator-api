using AutoMapper;
using Locator.api.AutoMapper;
using Locator.api.Dtos;
using Locator.Business.Models;
using Locator.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Locator.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;

        public CarsController(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCars()
        {
            var carList = _mapper.Map<IEnumerable<CarDto>>(await _context.Cars
                .Include(p => p.Characteristics)
                .Include(p => p.Optional)
                .ToListAsync());

            return Ok(carList);
        }

        // POST: api/Cars
        [HttpPost]
        public async Task<ActionResult<CarDto>> PostCar(CarDto carDto)
        {
            if (carDto == null)
                return BadRequest();

            var car = _mapper.Map<Car>(carDto);
            car.Characteristics.CarId = car.Id;
            car.Optional.CarId = car.Id;
            carDto.Characteristics.CarId = car.Id;
            carDto.Optional.CarId = car.Id;

            _context.Cars.Add(car);

            await _context.SaveChangesAsync();

            return Ok(carDto);
        }

        // PUT: api/Cars/5
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> PutCar(Guid id, CarDtoUpdate carDtoUpdate)
        {

            if (id != carDtoUpdate.Id) return BadRequest();

            var car = _mapper.Map<Car>(carDtoUpdate);
            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE: api/cars/5
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteCar(Guid id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var characteristic = await _context.Characteristics.FirstOrDefaultAsync(x => x.CarId == id);
            if (characteristic != null)
                _context.Characteristics.Remove(characteristic);

            var optional = await _context.Opcionals.FirstOrDefaultAsync(x => x.CarId == id);
            if (optional != null)
                _context.Opcionals.Remove(optional);

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool CarExists(Guid id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
