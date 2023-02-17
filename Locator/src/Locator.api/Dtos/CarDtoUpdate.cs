using System.ComponentModel.DataAnnotations;

namespace Locator.api.Dtos
{
    public class CarDtoUpdate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string YearOfManufacture { get; set; }
        public string Version { get; set; }
        public string Plate { get; set; }
        public string TypeOfUse { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
        public CharacteristicDto Characteristics { get; set; }
        public OptionalDto Optional { get; set; }
    }
}
