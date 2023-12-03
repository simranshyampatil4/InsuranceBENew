using InsuranceApp.Models;
using InsuranceApp.Repository;

namespace InsuranceApp.Services
{
    public class RoleService:IRoleService
    {
        private IEntityRepository<Role> _entityRepository;
        public RoleService(IEntityRepository<Role> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public List<Role> GetAll()
        {
            var roleQuery = _entityRepository.Get();
            var roles = roleQuery.Where(role => role.IsActive)
                .ToList();
            return roles;
        }
        public Role Get(int id)
        {
            var roleQuery = _entityRepository.Get();
            var role = roleQuery.Where(role => role.RoleId == id && role.IsActive).FirstOrDefault();
            return role;
        }
        public Role Check(int id)
        {
            return _entityRepository.Get(id);
        }
        public int Add(Role role)
        {
            return _entityRepository.Add(role);
        }
        public Role Update(Role role)
        {
            return _entityRepository.Update(role);
        }
        public void Delete(Role role)
        {
            _entityRepository.Delete(role);
        }
    }
}
