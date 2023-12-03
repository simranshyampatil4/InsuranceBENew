using InsuranceApp.Models;

namespace InsuranceApp.Services
{
    public interface IRoleService
    {
        public List<Role> GetAll();
        public Role Get(int id);
        public Role Check(int id);
        public int Add(Role role);
        public Role Update(Role role);
        public void Delete(Role role);
    }
}
