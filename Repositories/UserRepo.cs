using WebApplication12.Data;
using WebApplication12.ViewModels;

namespace WebApplication12.Repositories
{
    public class UserRepo
    {
        ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserVM> GetEmails()
        {
            IEnumerable<UserVM> users =
             _context.Users.Select(u => new UserVM() { Email = u.Email });

            return users;

        }
    }
}
