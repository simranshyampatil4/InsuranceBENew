using InsuranceApp.Models;
using InsuranceApp.Repository;
using static InsuranceApp.Services.CommissionService;

namespace InsuranceApp.Services
{
    public class CommissionService:ICommissionService
    {
            private IEntityRepository<Commission> _entityRepository;

            public CommissionService(IEntityRepository<Commission> entityRepository)
            {
                _entityRepository = entityRepository;
            }

            public List<Commission> GetAll()
            {
                var commissionQuery = _entityRepository.Get();
                var commissions = commissionQuery.Where(commission => commission.IsActive).ToList();
                return commissions;
            }

            public Commission Get(int id)
            {
                var commissionQuery = _entityRepository.Get();
                var commission = commissionQuery.Where(commission => commission.CommissionId == id).FirstOrDefault();
                return commission;
            }

            public Commission Check(int id)
            {
                return _entityRepository.Get(id);
            }

            public int Add(Commission commission)
            {
                return _entityRepository.Add(commission);
            }

            public Commission Update(Commission commission)
            {
                return _entityRepository.Update(commission);
            }

            public void Delete(Commission commission)
            {
                _entityRepository.Delete(commission);
            }
    }
}
