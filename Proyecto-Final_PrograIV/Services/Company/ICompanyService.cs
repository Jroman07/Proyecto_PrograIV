using Proyecto_Final_PrograIV.Entities;

namespace Proyecto_Final_PrograIV.Services.CompanyService
{
    public interface ICompanyService
    {
        public Company AddCompany(Company company);
        public void DeleteCompanyById(int id);
        public List<Company> GetAllCompanies();
        /*public List<Company> GetCompanyByName(string companyName);*/
        public Company GettCompanyById(int id);
        public Company UpdateCompany(int id, Company company);
    }
}
