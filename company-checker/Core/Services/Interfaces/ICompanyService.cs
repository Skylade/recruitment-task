using Core.Utils;
using Data.Entities;

namespace Core.Services.Interfaces
{
    public interface ICompanyService
    {
        public Task<ServiceResponse<Company>> GetCompanyFromAPI(string nip, DateTime date);
        public Task<ServiceResponse<IEnumerable<Company>>> GetCompaniesFromDb();
    }
}
