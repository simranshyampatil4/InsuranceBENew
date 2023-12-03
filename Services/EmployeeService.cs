using InsuranceApp.Models;
using InsuranceApp.Repository;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApp.Services
{
    public class EmployeeService:IEmployeeService
    {
        private IEntityRepository<Employee> _entityRepository;

        public EmployeeService(IEntityRepository<Employee> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public Employee GetByUserId(int id)
        {
            var employeeData = _entityRepository.Get();
            var employee = employeeData.Where(q => q.UserId == id).FirstOrDefault();
            return employee;
        }
        public List<Employee> GetAll()
        {
            var employeeQuery = _entityRepository.Get();
            var employees = employeeQuery.Where(employee => employee.IsActive)
                                  .ToList();
            return employees;
        }

        public Employee Get(int id)
        {
            var employeeQuery = _entityRepository.Get();
            var employee = employeeQuery.Where(employee => employee.EmployeeId == id && employee.IsActive).FirstOrDefault();
            return employee;
        }
        public Employee Check(int id)
        {
            return _entityRepository.Get(id);
        }
        public int Add(Employee employee)
        {
            return _entityRepository.Add(employee);
        }

        public Employee Update(Employee employee)
        {
            return _entityRepository.Update(employee);
        }

        public void Delete(Employee employee)
        {
            _entityRepository.Delete(employee);
        }
    }
}
