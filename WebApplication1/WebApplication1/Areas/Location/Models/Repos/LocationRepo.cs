using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using WebApplication1.Models;


namespace WebApplication1.Models.Repos
{
    public class LocationRepo : BaseRepo<Location>, IRepo<Location>
    {
        public LocationRepo()
        {
            Table = Context.Locations;
        }

        public int Delete(int id, byte[] timeStamp)
        {
            Context.Entry(new Location(){ LocationId = id}).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(int id, byte[] timeStamp)
        {
            Context.Entry(new Location() { LocationId = id }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
    }
}