using InsuranceApp.Models;

namespace InsuranceApp.Services
{
    public interface IEmployeeService
    {
        public List<Employee> GetAll();
        public Employee Get(int id);
        public Employee Check(int id);
        public int Add(Employee employee);
        public Employee Update(Employee employee);
        public void Delete(Employee employee);
        public Employee GetByUserId(int id);
    }
}
