using InsuranceApp.Models;
using InsuranceApp.Repository;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApp.Services
{
    public class CustomerService : ICustomerService
    {
        private IEntityRepository<Customer> _entityRepository;

        public CustomerService(IEntityRepository<Customer> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public List<Customer> GetAll()
        {
            var customerQuery = _entityRepository.Get();
            var customers = customerQuery.Where(customer => customer.IsActive)
                                        .Include(customer => customer.InsurancePolicies)
                                        .Include(customer => customer.Documents)
                                        .ToList();
            return customers;
        }

        public Customer Get(int id)
        {
            var customerQuery = _entityRepository.Get();
            var customer = customerQuery.Where(customer => customer.CustomerId == id && customer.IsActive)
                                      .FirstOrDefault();
            return customer;
        }

        public Customer GetByUserId(int id)
        {
            var customerData = _entityRepository.Get();
            var customer = customerData.Where(q => q.UserId == id).FirstOrDefault();
            return customer;
        }

        public int Add(Customer customer)
        {
            return _entityRepository.Add(customer);
        }
        public Customer Check(int id)
        {
            return _entityRepository.Get(id);
        }


        public Customer Update(Customer customer)
        {
            return _entityRepository.Update(customer);
        }

        public void Delete(Customer customer)
        {
            _entityRepository.Delete(customer);
        }
        public List<Customer> GetByAgentId(int agentId)
        {
            return _entityRepository.Get().Where(c => c.AgentId == agentId).ToList();
        }

    }
}


