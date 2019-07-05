using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.Areas.Location.Models.Repos
{
    public class OrderRepo : BaseRepo<Order>, IRepo<Order>
    {
        public OrderRepo()
        {
            Table = Context.Orders;
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