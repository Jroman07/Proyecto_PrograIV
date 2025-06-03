using Microsoft.EntityFrameworkCore;
using Proyecto_Final_PrograIV.Entities;
using Proyecto_Final_PrograIV.FinalProjectDataBase;

namespace Proyecto_Final_PrograIV.Services.CompanyService
{
    public class CompanyService:ICompanyService
    {
        private readonly FinalProjectDbContext _dbContext;

        public CompanyService(FinalProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Company AddCompany(Company company)
        {
            _dbContext.Companies.Add(company);
            _dbContext.SaveChanges();

            return company;
        }
        public void DeleteCompanyById(int id)
        {
            Company? DeleteCompany = _dbContext.Companies.Find(id);

            if (DeleteCompany != null)
            {
                _dbContext.Companies.Remove(DeleteCompany);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Company not found");
            }
        }

        public List<Company> GetAllCompanies()
        {
            return _dbContext.Companies.Include(x => x.Offers).ToList();
        }
        public Company GettCompanyById(int id)
        {
            Company? company = _dbContext.Companies.Find(id);

            if (company == null)
            {
                throw new Exception("Compnay not found");
            }
            return company;
        }
        public Company UpdateCompany(int id, Company company)
        {
            Company? updateCompany = _dbContext.Companies.Find(id);
            if (updateCompany == null)
            {
                throw new Exception("Candidate not found");
            }
            else
            {
                updateCompany.Name = company.Name;
                updateCompany.WebSite = company.WebSite;
                updateCompany.Email = company.Email;
                return updateCompany;
            }
        }
    }
}