using RealEstateAPI.Models;

namespace RealEstateAPI.Services
{
    public class BrandService : IBrandService
    {
        private static readonly List<BrandDto> _brands = new();

        public List<BrandDto> GetAll() => _brands;

        public void Create(BrandDto brand)
        {
            if (_brands.Any(b => b.Name == brand.Name))
                throw new InvalidOperationException("Brand already exists.");
            _brands.Add(brand);
        }

        public void Update(BrandDto brand)
        {
            var existing = _brands.FirstOrDefault(b => b.Name == brand.Name);
            if (existing == null)
                throw new InvalidOperationException("Brand not found.");

            existing.Price = brand.Price;
        }

        public void Delete(string name)
        {
            var brand = _brands.FirstOrDefault(b => b.Name == name);
            if (brand == null)
                throw new InvalidOperationException("Brand not found.");
            if (brand != null)
                _brands.Remove(brand);
        }
    }
}
