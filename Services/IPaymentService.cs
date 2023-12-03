using InsuranceApp.Models;

namespace InsuranceApp.Services
{
    public interface IPaymentService
    {
        public List<Payment> GetAll();
        public Payment Get(int id);
        public Payment Check(int id);
        public int Add(Payment payment);
        public Payment Update(Payment payment);
        public void Delete(Payment payment);
    }
}
