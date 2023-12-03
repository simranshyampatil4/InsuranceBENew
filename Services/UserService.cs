using InsuranceApp.DTO;
using InsuranceApp.Models;
using InsuranceApp.Repository;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApp.Services
{
    public class UserService:IUserService
    {
        private IEntityRepository<User> _entityRepository;
        public UserService(IEntityRepository<User> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public List<User> GetAll()
        {
            var userQuery = _entityRepository.Get();
            var users = userQuery.Where(user => user.IsActive)
                .ToList();
            return users;
        }
        public User Get(int id)
        {
            var userQuery = _entityRepository.Get();
            var user = userQuery.Where(user => user.UserId == id && user.IsActive).FirstOrDefault();
            return user;
        }
        public User Check(int id)
        {
            return _entityRepository.Get(id);
        }
        public int Add(UserDto userDto)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            var newUser = new User()
            {
                UserName = userDto.UserName,
                Password = passwordHash,
                RoleId = userDto.RoleId,
                IsActive = true
            };
            _entityRepository.Add(newUser);
            //return FindUser(newUser.UserName);
            return newUser.UserId;
            //return _entityRepository.Add(user);
        }
        public User Update(User user)
        {
            return _entityRepository.Update(user);
        }
        public void Delete(User user)
        {
            _entityRepository.Delete(user);
        }

        public User FindUser(string username)
        {
            return _entityRepository.FindUser(username);
        }

        public string GetRoleName(User user)
        {
            return _entityRepository.GetRoleName(user);
        }
    }
}
