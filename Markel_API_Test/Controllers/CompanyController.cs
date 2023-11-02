using Markel_API_Test.Data;
using Markel_API_Test.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Markel_API_Test.Controllers
{
    public class CompanyController : ControllerBase
    {
        private readonly List<Company> _companies;
        public CompanyController()
        {
            _companies = new List<Company>
            {
                new Company
                {
                    Id = 1,
                    Name = "Hamster Wheels Co",
                    Address1 = "123 Main St",
                    PostCode = "12345",
                    Country = "United Kingdom",
                    Active = true,
                    InsuranceEndDate = DateTime.UtcNow.AddYears(1)
                },
                new Company
                {
                    Id = 2,
                    Name = "Cheese Company",
                    Address1 = "456 Oak St",
                    PostCode = "67890",
                    Country = "France",
                    Active = false,
                    InsuranceEndDate = DateTime.UtcNow.AddMonths(-1)
                },
                new Company
                {
                    Id = 3,
                    Name = "Sheffield Wednesday Brankrupt Company",
                    Address1 = "456 Oak St",
                    PostCode = "67890",
                    Country = "United Kingdom",
                    Active = false,
                    InsuranceEndDate = DateTime.UtcNow.AddMonths(-5)
                }

            };
        }

        [HttpGet("getCompanyById/{companyId}")]
        public ActionResult<CompanyResponse> GetCompany(int companyId)
        {
            Company company = new Company();
            company = _companies.Find(c => c.Id == companyId);

            if (company == null)
            {
                return NotFound();
            }

            bool hasActiveInsurancePolicy = company.Active && company.InsuranceEndDate >= DateTime.UtcNow;

            var response = new CompanyResponse
            {
                Id = company.Id,
                Name = company.Name,
                Address1 = company.Address1,
                Address2 = company.Address2,
                Address3 = company.Address3,
                PostCode = company.PostCode,
                Country = company.Country,
                Active = company.Active,
                InsuranceEndDate = company.InsuranceEndDate,
                HasActiveInsurancePolicy = hasActiveInsurancePolicy
            };

            return Ok(response);
        }

        
    }
}
