using Core.Enums;
using Core.Services.Interfaces;
using Core.Utils;
using Data.Entities;
using Data.Repositories.Interfaces;
using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Core.Services
{
    public class CompanyService : ICompanyService
    {
        private static HttpClient client;
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            client = new HttpClient();
            _companyRepository = companyRepository;
        }

        public async Task<ServiceResponse<IEnumerable<Company>>> GetCompaniesFromDb()
        {
            var getCompaniesResponse = await _companyRepository.GetCompanies();

            return new ServiceResponse<IEnumerable<Company>>(HttpStatusCode.OK, getCompaniesResponse);
        }

        public async Task<ServiceResponse<Company>> GetCompanyFromAPI(string nip, DateTime date)
        {
            Company company = null;

            HttpResponseMessage response = await client.GetAsync($"{WlApiEnums.NipEndpointUrl}/{nip}?date={date.ToString("yyyy-MM-dd")}");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                company = await Mapper.MapCompanyFromResponse(company, response);

            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                JsonNode responseNode = JsonNode.Parse(content)!;

                JsonNode messageNode = responseNode?["message"]!;
                var message = messageNode?.Deserialize<string>();

                return new ServiceResponse<Company>(response.StatusCode, new List<string>() { message }, company);
            }

            var saveCompanyResponse = await _companyRepository.SaveCompany(company);

            if (saveCompanyResponse == Guid.Empty)
            {
                return new ServiceResponse<Company>(HttpStatusCode.InternalServerError, new List<string>() { "Error while saving company to database" }, company);
            }

            return new ServiceResponse<Company>(HttpStatusCode.OK, company); ;
        }
    }
}
