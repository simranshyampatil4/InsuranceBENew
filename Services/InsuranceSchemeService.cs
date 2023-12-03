using InsuranceApp.Models;
using InsuranceApp.Repository;

namespace InsuranceApp.Services
{
    public class InsuranceSchemeService:IInsuranceSchemeService
    {
        private IEntityRepository<InsuranceScheme> _entityRepository;
        public InsuranceSchemeService(IEntityRepository<InsuranceScheme> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public List<InsuranceScheme> GetAll()
        {
            var insuranceSchemeQuery = _entityRepository.Get();
            var insuranceSchemes = insuranceSchemeQuery.Where(insurscheme => insurscheme.IsActive)
                .ToList();
            return insuranceSchemes;
        }
        public InsuranceScheme Get(int id)
        {
            var insuranceSchemeQuery = _entityRepository.Get();
            var insuranceSchemes = insuranceSchemeQuery.Where(insurScheme => insurScheme.SchemeId == id && insurScheme.IsActive).FirstOrDefault();
            return insuranceSchemes;
        }
        public InsuranceScheme Check(int id)
        {
            return _entityRepository.Get(id);
        }
        public int Add(InsuranceScheme insuranceScheme)
        {
            return _entityRepository.Add(insuranceScheme);
        }
        public InsuranceScheme Update(InsuranceScheme insuranceScheme)
        {
            return _entityRepository.Update(insuranceScheme);
        }
        public void Delete(InsuranceScheme insuranceScheme)
        {
            _entityRepository.Delete(insuranceScheme);
        }
    }
}
