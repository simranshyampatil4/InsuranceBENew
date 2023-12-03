using InsuranceApp.Models;
using InsuranceApp.Repository;

namespace InsuranceApp.Services
{
    public class InsurancePolicyService:IInsurancePolicyService
    {
        private IEntityRepository<InsurancePolicy> _entityRepository;
        public InsurancePolicyService(IEntityRepository<InsurancePolicy> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public List<InsurancePolicy> GetAll()
        {
            var insurancePolicyQuery = _entityRepository.Get();
            var insurancePolicies = insurancePolicyQuery.Where(insurpol => insurpol.IsActive)
                .ToList();
            return insurancePolicies;
        }
        public InsurancePolicy Get(int id)
        {
            var insurancePolicyQuery = _entityRepository.Get();
            var insurancePolicy = insurancePolicyQuery.Where(insurPolicy => insurPolicy.PolicyNo == id && insurPolicy.IsActive).FirstOrDefault();
            return insurancePolicy;
        }
        public InsurancePolicy Check(int id)
        {
            return _entityRepository.Get(id);
        }
        public int Add(InsurancePolicy insurancePolicy)
        {
            return _entityRepository.Add(insurancePolicy);
        }
        public InsurancePolicy Update(InsurancePolicy insurancePolicy)
        {
            return _entityRepository.Update(insurancePolicy);
        }
        public void Delete(InsurancePolicy insurancePolicy)
        {
            _entityRepository.Delete(insurancePolicy);
        }
    }
}
