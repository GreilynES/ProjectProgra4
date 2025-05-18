using ProyectoProgra4.Entities;
using ProyectoProgra4.ProjectDataBase;

namespace ProyectoProgra4.Services.CompanyC
{
    public class CompanyService : ICompany
    {
        private readonly ProjectDataBaseContext _dbContext;

        public CompanyService(ProjectDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Company> GetAllCompanies()
        {
            return _dbContext.Companies.ToList();
        }

        public Company GetCompanyById(int id)
        {
            var company = _dbContext.Companies.Find(id);
            if (company == null) throw new Exception("Company not found");
            return company;
        }

        public Company AddCompany(Company company)
        {
            _dbContext.Companies.Add(company);
            _dbContext.SaveChanges();
            return company;
        }

        public Company UpdateCompany(int id, Company company)
        {
            var existingCompany = _dbContext.Companies.Find(id);
            if (existingCompany == null) throw new Exception("Company not found");

            existingCompany.Name = company.Name;
            existingCompany.WebSite = company.WebSite;
            existingCompany.Email = company.Email;

            _dbContext.SaveChanges();
            return existingCompany;
        }

        public void DeleteCompany(int id)
        {
            var company = _dbContext.Companies.Find(id);
            if (company == null) throw new Exception("Company not found");

            _dbContext.Companies.Remove(company);
            _dbContext.SaveChanges();
        }
    }
}
