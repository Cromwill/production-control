using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Areas.Location.Models.Repos
{
    public class OrderRepo : BaseRepo<Order>, IRepo<Order>
    {
        public OrderRepo()
        {
            Table = Context.Orders;
        }

        ///<summary> Возвращает все T принадлежащие данному userId</summary>
        public IEnumerable<Order> GetOrdersForUser(string userId)
        {
            var orders = GetAll().Where(d => d.UserId.Contains(userId));
            return orders;
        }

        ///<summary> Возвращает все T принадлежащие данному userId в асинхронном режиме</summary>
        public async Task<IEnumerable<Order>> GetOrdersForUserAsync(string userId)
        {
            var loc = await GetAllAsync();
            return loc.Where(d => d.UserId.Contains(userId));
        }

        public int Delete(int id, byte[] timeStamp)
        {
            Context.Entry(new Order(){ OrderId = id}).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(int id, byte[] timeStamp)
        {
            Context.Entry(new Order() { OrderId = id }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
    }
}