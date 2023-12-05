using InsuranceApp.Models;

namespace InsuranceApp.Services
{
    public interface ICommissionWithdrawalService
    {
        public List<CommissionWithdrawal> GetAll();
        public CommissionWithdrawal Get(int id);
        public CommissionWithdrawal Check(int id);

        public int Add(CommissionWithdrawal commisionWithdrawal);
        public CommissionWithdrawal Update(CommissionWithdrawal commissionWithdrawal);

        public void Delete(CommissionWithdrawal commissionWithdrawal);
    }
}
