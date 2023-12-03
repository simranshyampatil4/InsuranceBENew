using InsuranceApp.DTO;
using InsuranceApp.Models;

namespace InsuranceApp.Services
{
    public interface IUserService
    {
        public List<User> GetAll();
        public User Get(int id);
        public User Check(int id);
        public int Add(UserDto userDto);
        public User Update(User user);
        public void Delete(User user);
        public User FindUser(string username);
        public string GetRoleName(User user);
    }
}
