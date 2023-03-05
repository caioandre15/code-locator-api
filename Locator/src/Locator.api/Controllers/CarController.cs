using AutoMapper;
using Locator.api.AutoMapper;
using Locator.api.Dtos;
using Locator.Models;
using Locator.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Locator.Business.Interface;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Locator.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CarController(IMapper mapper, ICarService carService)
        {
            _mapper = mapper;
            _carService = carService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCars()
        {

            var carList = _mapper.Map<IEnumerable<CarDto>>(await _carService.GetListCars());

            return Ok(carList);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CarDto>> GetCar(Guid id)
        {
            var car = _mapper.Map<CarDto>(await _carService.GetCarById(id));

            if (car == null) return NotFound();

            return Ok(car);
        }

        [HttpPost]
        public async Task<ActionResult> PostCar(CarDto carDto)
        {
            if (carDto == null)
                return BadRequest();

            var car = _mapper.Map<Car>(carDto);
            
            var result = await _carService.CreateCar(car);
            if (result <= 0) return BadRequest();

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> PutCar(Guid id, CarDtoUpdate carDtoUpdate)
        {

            if (id != carDtoUpdate.Id) return BadRequest();

            var car = await _carService.GetCarById(id);
            if (car == null) return NotFound();

            car = _mapper.Map(carDtoUpdate, car);
            var result = await _carService.UpdateCar(car);
            if (result <= 0) return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteCar(Guid id)
        {
            var car = await _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }

            var result = await _carService.DeleteCar(car);
            if (result <= 0) return BadRequest();

            return Ok();
        }
    }
}
