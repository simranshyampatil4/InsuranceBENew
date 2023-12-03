using InsuranceApp.Models;
using InsuranceApp.Repository;

namespace InsuranceApp.Services
{
    public class InsurancePlanService:IInsurancePlanService
    {
        private IEntityRepository<InsurancePlan> _entityRepository;
        public InsurancePlanService(IEntityRepository<InsurancePlan> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public List<InsurancePlan> GetAll()
        {
            var insurancePlanQuery = _entityRepository.Get();
            var insurancePlans = insurancePlanQuery.Where(insurplan => insurplan.IsActive)
                .ToList();
            return insurancePlans;
        }
        public InsurancePlan Get(int id)
        {
            var insurancePlanQuery = _entityRepository.Get();
            var insurancePlan = insurancePlanQuery.Where(insurplan => insurplan.PlanId == id && insurplan.IsActive).FirstOrDefault();
            return insurancePlan;
        }
        public InsurancePlan Check(int id)
        {
            return _entityRepository.Get(id);
        }
        public int Add(InsurancePlan insurancePlan)
        {
            return _entityRepository.Add(insurancePlan);
        }
        public InsurancePlan Update(InsurancePlan insurancePlan)
        {
            return _entityRepository.Update(insurancePlan);
        }
        public void Delete(InsurancePlan insurancePlan)
        {
            _entityRepository.Delete(insurancePlan);
        }
    }
}
