using InsuranceApp.Models;
using InsuranceApp.Repository;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApp.Services
{
    public class AdminService : IAdminService
    {
        private IEntityRepository<Admin> _entityRepository;

        public AdminService(IEntityRepository<Admin> entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public Admin GetByUserId(int id)
        {
            var adminData = _entityRepository.Get();
            var admin = adminData.Where(q=>q.UserId == id).FirstOrDefault();
            return admin;
        }
        public List<Admin> GetAll()
        {
            var adminQuery = _entityRepository.Get();
            var admins = adminQuery.Where(admin => admin.IsActive)
                                  .Include(admin => admin.User)
                                  .ToList();
            return admins;
        }

        public Admin Get(int id)
        {
            var adminQuery = _entityRepository.Get();
            var admin = adminQuery.Where(admin => admin.AdminId == id && admin.IsActive)
                                  .Include(admin => admin.User)
                                  .FirstOrDefault();
            return admin;
        }

        public Admin Check(int id)
        {
            return _entityRepository.Get(id);
        }

        public int Add(Admin admin)
        {
            return _entityRepository.Add(admin);
        }

        public Admin Update(Admin admin)
        {
            return _entityRepository.Update(admin);
        }

        public void Delete(Admin admin)
        {
            _entityRepository.Delete(admin);
        }
    }
}
    

