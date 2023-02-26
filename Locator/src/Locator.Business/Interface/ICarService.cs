using Locator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Business.Interface
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetListCars();
        Task<Car> GetCarById(Guid carId);
        Task<int> CreateCar(Car car);
        Task<int> UpdateCar(Car car);
        Task<int> DeleteCar(Car car);
    }
}
