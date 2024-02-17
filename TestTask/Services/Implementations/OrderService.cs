using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private ApplicationDbContext _db;

        public OrderService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<Order> GetOrder()
        {
            var orderWithMaxAmount = _db.Orders.OrderByDescending(o => o.Price * o.Quantity).FirstOrDefaultAsync();

            return orderWithMaxAmount;
        }

        public Task<List<Order>> GetOrders()
        {
            var orders = _db.Orders.Where(o => o.Quantity > 10).ToListAsync();

            return orders;
        }
    }
}
