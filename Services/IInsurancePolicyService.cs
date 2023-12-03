using InsuranceApp.Models;

namespace InsuranceApp.Services
{
    public interface IInsurancePolicyService
    {
        public List<InsurancePolicy> GetAll();
        public InsurancePolicy Get(int id);
        public InsurancePolicy Check(int id);
        public int Add(InsurancePolicy insurancePolicy);
        public InsurancePolicy Update(InsurancePolicy insurancePolicy);
        public void Delete(InsurancePolicy insurancePolicy);

    }
}
