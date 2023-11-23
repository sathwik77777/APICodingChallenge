using APIChallenge.Entities;
namespace APIChallenge.Services
{
    public interface IUserService
    {
         void AddUser(User user);//Done
         List<User> GetAllUsers();
         User ValidateUser(string username, string password);
         void UpdateUser(User user);
    }
}
