using InsuranceApp.Data;
using InsuranceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApp.Repository
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class
    {
        private MyContext _context;
        private readonly DbSet<T> _table;

        public EntityRepository(MyContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public IQueryable<T> Get()
        {
            return _table.AsQueryable();
        }
        public T Get(int id)
        {
            var entity = _table.Find(id);
            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;
            return entity;

        }
        public int Add(T entity)
        {
            _table.Add(entity);
            return _context.SaveChanges();
        }
        public T Update(T entity)
        {
            _table.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            var isActiveProperty = entity.GetType().GetProperty("IsActive");
            if (isActiveProperty != null)
            {
                isActiveProperty.SetValue(entity, false);
                _table.Update(entity);
            }
            else
                _table.Remove(entity);
            _context.SaveChanges();
        }

        public T FindUser(string username)
        {
            if (typeof(T) == typeof(User))
            {
                // Assuming T is User in this context
                return _table.OfType<User>().FirstOrDefault(user => user.UserName == username) as T;
            }
            else
            {
                // Handle other entity types if neded
                return null;
            }
        }

        public string GetRoleName(User user)
        {
            return _context.Roles.Where(role => role.RoleId == user.RoleId).FirstOrDefault().RoleName;
        }
        //public string GetRoleName(int roleId)
        //{
        //    // Assuming T is User in this context
        //    var roleName = _context.Roles.Where(role => role.RoleId == roleId).FirstOrDefault()?.RoleName;
        //    return roleName;
        //}
    }
}
