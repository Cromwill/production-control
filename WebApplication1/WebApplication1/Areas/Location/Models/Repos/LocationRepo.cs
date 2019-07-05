using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using WebApplication1.Models;


namespace WebApplication1.Areas.Location.Models.Repos
{
    public class LocationRepo : BaseRepo<Location>, IRepo<Location>
    {
        public LocationRepo()
        {
            Table = Context.Locations;
        }

        ///<summary> Возвращает все T принадлежащие данному userId</summary>
        public IEnumerable<Location> GetLocationsForUser(string userId)
        {
            var loc = GetAll().Where(d => d.UsersId.Contains(userId));
            return loc;
        }

        public async Task<IEnumerable<Location>> GetLocationsForUserAsync(string userId)
        {
            var loc = await GetAllAsync();
            return loc.Where(d => d.UsersId.Contains(userId));
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