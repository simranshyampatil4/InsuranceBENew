using InsuranceApp.Models;
using InsuranceApp.Repository;

namespace InsuranceApp.Services
{
    public class CommissionWithdrawalService:ICommissionWithdrawalService
    {
        private IEntityRepository<CommissionWithdrawal> _entityRepository;

        public CommissionWithdrawalService(IEntityRepository<CommissionWithdrawal> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public List<CommissionWithdrawal> GetAll()
        {
            var commissionWithQuery = _entityRepository.Get();
            var commissionWiths = commissionWithQuery.Where(comm => comm.IsActive).ToList();
            return commissionWiths;
        }

        public CommissionWithdrawal Get(int id)
        {
            var commissionWithQuery = _entityRepository.Get();
            var commissionWith = commissionWithQuery.Where(commission => commission.Id == id).FirstOrDefault();
            return commissionWith;
        }

        public CommissionWithdrawal Check(int id)
        {
            return _entityRepository.Get(id);
        }

        public int Add(CommissionWithdrawal commissionWithdrawal)
        {
            return _entityRepository.Add(commissionWithdrawal);
        }

        public CommissionWithdrawal Update(CommissionWithdrawal commissionWithdrawal)
        {
            return _entityRepository.Update(commissionWithdrawal);
        }

        public void Delete(CommissionWithdrawal commissionWithdrawal)
        {
            _entityRepository.Delete(commissionWithdrawal);
        }
    }
}
