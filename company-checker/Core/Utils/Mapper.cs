using Data.Entities;
using Newtonsoft.Json;

namespace Core.Utils
{
    public static class Mapper
    {
        public static async Task<Company> MapCompanyFromResponse(Company company, HttpResponseMessage response)
        {
            string responseContent = await response.Content.ReadAsStringAsync();

            dynamic responseObject = JsonConvert.DeserializeObject(responseContent);

            dynamic result = responseObject?.result;

            var BankAccountsList = new List<BankAccount>();
            foreach (var account in result.subject.accountNumbers)
            {
                BankAccountsList.Add(new BankAccount() { AccountNumber = account.ToString() });
            }

            var RepresentativesList = new List<Representative>();
            foreach (var representative in result.subject.representatives)
            {
                RepresentativesList.Add(new Representative()
                {
                    FirstName = representative.firstName,
                    LastName = representative.lastName,
                    Nip = representative.nip,
                    CompanyName = representative.companyName
                });
            }

            // Map the properties to the Company object
            company = new Company
            {
                Regon = result.subject.regon,
                Nip = result.subject.nip,
                RestorationDate = result.subject.restorationDate,
                WorkingAddress = result.subject.workingAddress,
                HasVirtualAccounts = result.subject.hasVirtualAccounts,
                StatusVat = result.subject.statusVat,
                Krs = result.subject.krs,
                RestorationBasis = result.subject.restorationBasis,
                AccountNumbers = BankAccountsList,
                RegistrationDenialBasis = result.subject.registrationDenialBasis,
                RemovalDate = result.subject.removalDate,
                Name = result.subject.name,
                RegistrationLegalDate = result.subject.registrationLegalDate,
                RemovalBasis = result.subject.removalBasis,
                Pesel = result.subject.pesel,
                Representatives = RepresentativesList,
                ResidenceAddress = result.subject.residenceAddress,
                RegistrationDenialDate = result.subject.registrationDenialDate,
                RequestDateTime = result.requestDateTime,
                RequestId = result.requestId
            };
            return company;
        }
    }
}
