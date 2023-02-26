using Locator.Business.Interface;
using Locator.Data.Context;
using Locator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Business.Service
{
    public class CarService : ICarService
    {
        private readonly DataBaseContext _context;
        public CarService(DataBaseContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<Car>> GetListCars()
        {
            var carList = await _context.Cars
                .Include(p => p.Characteristics)
                .Include(p => p.Optional)
                .ToListAsync();

            return carList;
        }

        public async Task<Car> GetCarById(Guid carId)
        {
            var car = await _context.Cars
                .Include(p => p.Characteristics)
                .Include(p => p.Optional)
                .FirstOrDefaultAsync(x => x.Id == carId);

            return car;
        }

        public async Task<int> CreateCar(Car car)
        {
            car.Characteristics.CarId = car.Id;
            car.Optional.CarId = car.Id;
            
            _context.Cars.Add(car);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateCar(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCar(Car car)
        {
            var characteristic = await _context.Characteristics.FirstOrDefaultAsync(x => x.CarId == car.Id);
            if (characteristic != null)
                _context.Characteristics.Remove(characteristic);

            var optional = await _context.Opcionals.FirstOrDefaultAsync(x => x.CarId == car.Id);
            if (optional != null)
                _context.Opcionals.Remove(optional);

            _context.Cars.Remove(car);
            return await _context.SaveChangesAsync();

        }
    }
}
