using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoProgra4.Entities;
using ProyectoProgra4.Services.CompanyC;

namespace Proyecto_Final_PrograIV.Controllers
{
    [Authorize ]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompany _companyService;

        public CompanyController(ICompany companyService)
        {
            _companyService = companyService;
        }

        // GET: api/Company
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return _companyService.GetAllCompanies();
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        public Company Get(int id)
        {
            return _companyService.GetCompanyById(id);
        }

        // POST: api/Company
        [HttpPost]
        public Company Post([FromBody] Company company)
        {
            return _companyService.AddCompany(company);
        }

        // PUT: api/Company/5
        [HttpPut("{id}")]
        public Company Put(int id, [FromBody] Company company)
        {
            return _companyService.UpdateCompany(id, company);
        }

        // DELETE: api/Company/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _companyService.DeleteCompany(id);
        }
    }
}
