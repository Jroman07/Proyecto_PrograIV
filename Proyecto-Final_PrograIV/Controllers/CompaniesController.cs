using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_PrograIV.Entities;
using Proyecto_Final_PrograIV.Services;
using Proyecto_Final_PrograIV.Services.CompanyService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_Final_PrograIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompaniesController(ICompanyService companyService) { 
            _companyService = companyService;
        }
        // GET: api/<CompanyController>
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return _companyService.GetAllCompanies();
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public Company Get(int id)
        {
            return _companyService.GettCompanyById(id);
        }

        // POST api/<CompanyController>
        [HttpPost]
        public Company Post([FromBody] Company company)
        {
            return _companyService.AddCompany(company);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public Company Put(int id, [FromBody] Company company)
        {
            return _companyService.UpdateCompany(id,company);
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _companyService.DeleteCompanyById(id);
        }
    }
}
