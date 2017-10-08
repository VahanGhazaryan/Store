using Store.Domain.Abstract;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<Address> Addresses
        {
            get { return context.Addresses; }
        }
        public void SaveAddr(Address addr)
        {
            Address dbEntry = context.Addresses.Find(new object[] {addr.UserID, addr.AddrType});
            if (dbEntry != null)
            {
                dbEntry = addr;
            }
            else
            {
                context.Addresses.Add(addr);
            }
            context.SaveChanges();
        }
    }
}
