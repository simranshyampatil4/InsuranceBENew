using InsuranceApp.Models;
using InsuranceApp.Repository;

namespace InsuranceApp.Services
{
    public class PaymentService:IPaymentService
    {
        private IEntityRepository<Payment> _entityRepository;
        public PaymentService(IEntityRepository<Payment> entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public List<Payment> GetAll()
        {
            var paymentQuery = _entityRepository.Get();
            var payments = paymentQuery.Where(payment => payment.IsActive)
                .ToList();
            return payments;
        }
        public Payment Get(int id)
        {
            var paymentQuery = _entityRepository.Get();
            var payment = paymentQuery.Where(payment => payment.PaymentId == id && payment.IsActive).FirstOrDefault();
            return payment;
        }
        public Payment Check(int id)
        {
            return _entityRepository.Get(id);
        }
        public int Add(Payment payment)
        {
            return _entityRepository.Add(payment);
        }
        public Payment Update(Payment payment)
        {
            return _entityRepository.Update(payment);
        }
        public void Delete(Payment payment)
        {
            _entityRepository.Delete(payment);
        }
    }
}
