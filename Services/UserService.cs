using APIChallenge.Entities;
using APIChallenge.Database;
namespace APIChallenge.Services
{
    public class UserService : IUserService
    {
        private readonly MyContext _context;

        public UserService(MyContext context)
        {
            _context = context;
        }

        public void AddUser(User user) 
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User ValidateUser(string email, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
        }

        public void UpdateUser(User user) 
        {
            _context.Users.Update(user);
                _context.SaveChanges();
        }

        

        User IUserService.ValidateUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
