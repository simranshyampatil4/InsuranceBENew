using InsuranceApp.Models;

namespace InsuranceApp.Services
{
    public interface IInsurancePlanService
    {
        public List<InsurancePlan> GetAll();
        public InsurancePlan Get(int id);
        public InsurancePlan Check(int id);
        public int Add(InsurancePlan insurancePlan);
        public InsurancePlan Update(InsurancePlan insurancePlan);
        public void Delete(InsurancePlan insurancePlan);
    }

}
