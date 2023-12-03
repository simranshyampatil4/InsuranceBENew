using InsuranceApp.Models;

namespace InsuranceApp.Services
{
    public interface IInsuranceSchemeService
    {
        public List<InsuranceScheme> GetAll();
        public InsuranceScheme Get(int id);
        public InsuranceScheme Check(int id);
        public int Add(InsuranceScheme insuranceScheme);
        public InsuranceScheme Update(InsuranceScheme insuranceScheme);
        public void Delete(InsuranceScheme insuranceScheme);
    }
}
