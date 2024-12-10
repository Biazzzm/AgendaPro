using AgendaPro.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaPro.Api.Data
{
    public class AgendaDataContext : DbContext
    {
        public AgendaDataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }


    }
}
