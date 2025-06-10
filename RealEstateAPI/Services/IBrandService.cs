using RealEstateAPI.Models;

namespace RealEstateAPI.Services
{
    public interface IBrandService
    {
        List<BrandDto> GetAll();
        void Create(BrandDto brand);
        void Update(BrandDto brand);
        void Delete(string name);
    }
}
