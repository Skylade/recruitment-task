using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        protected DataBaseContext _context;

        public CompanyRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await _context.Companies.Include(company => company.AccountNumbers).OrderBy(company => company.RequestDateTime).ToListAsync();
        }

        public async Task<Guid> SaveCompany(Company company)
        {
            var created = await _context.Set<Company>().AddAsync(company);
            await _context.SaveChangesAsync();
            return created.Entity.Id;
        }
    }
}
