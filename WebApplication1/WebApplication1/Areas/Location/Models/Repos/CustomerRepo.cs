using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.Models.Repos
{
    public class CustomerRepo: BaseRepo<Customer>, IRepo<Customer>
    {
        public CustomerRepo()
        {
            Table = Context.Customers;
        }

        public int Delete(int id, byte[] timeStamp)
        {
            Context.Entry(new Customer() { CustId = id }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(int id, byte[] timeStamp)
        {
            Context.Entry(new Customer() { CustId = id }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
    }
}