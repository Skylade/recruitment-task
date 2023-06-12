using Core.Services.Interfaces;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class CompaniesController : BaseController
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("company/{nip}")]
        public async Task<ActionResult<Company>> Get([FromRoute] string nip, DateTime date)
        {
            var CompanyResponse = await _companyService.GetCompanyFromAPI(nip, date);

            return SendResponse(CompanyResponse);
        }

        [HttpGet("company/saved-requests")]
        public async Task<ActionResult<Company>> Get()
        {
            var CompaniesResponse = await _companyService.GetCompaniesFromDb();

            return SendResponse(CompaniesResponse);
        }
    }
}
