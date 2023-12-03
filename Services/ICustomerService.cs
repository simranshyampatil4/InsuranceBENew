using InsuranceApp.Models;

namespace InsuranceApp.Services
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        Customer Get(int id);
        int Add(Customer customer);
        public Customer Check(int id);

        public Customer GetByUserId(int id);
        Customer Update(Customer customer);
        public void Delete(Customer customer);
        public List<Customer> GetByAgentId(int agentId);
    }
}
