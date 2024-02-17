using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _db;

        public UserService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<User> GetUser()
        {
            var userWithMostOrders = _db.Users
                .OrderByDescending(u => u.Orders.Count)
                .FirstOrDefaultAsync();

            return userWithMostOrders;
        }

        public Task<List<User>> GetUsers()
        {
            var usersInactive = _db.Users.Where(u => u.Status == UserStatus.Inactive).ToListAsync();

            return usersInactive;
        }
    }
}
