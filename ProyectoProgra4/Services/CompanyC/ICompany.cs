using ProyectoProgra4.Entities;

namespace ProyectoProgra4.Services.CompanyC
{
    public interface ICompany
    {
        List<Company> GetAllCompanies();
        Company GetCompanyById(int id);
        Company AddCompany(Company company);
        Company UpdateCompany(int id, Company company);
        void DeleteCompany(int id);
    }
}
