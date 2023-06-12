using Data.Entities;

namespace Data.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompanies();
        Task<Guid> SaveCompany(Company company);
    }
}
