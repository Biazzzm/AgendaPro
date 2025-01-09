
using AgendaPro.Api.Data;
using AgendaPro.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaPro.Api.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AgendaDataContext context;

        public ContactRepository(AgendaDataContext context)
        {
            this.context = context;
        }

        public async Task AlterarAsync(Contact contato)

        {
            context.Entry(contato).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();

        }

        public async Task CriarAsync(Contact contato)
        {
            context.Contacts.Add(contato);
            await context.SaveChangesAsync();
        }

        public async Task DeletarAsync(int id)
        {
            var contato = context.Contacts.FirstOrDefault(x => x.Id == id);

            if (contato == null)
            {
                throw new KeyNotFoundException($"Contato com o Id {id} não encontrado.");
            }

            context.Contacts.Remove(contato);
            await context.SaveChangesAsync();
        }

        public async Task<Contact?> GetAsync(int id)
        {
            if (id <= 0)
            {
                throw new KeyNotFoundException($"Contato com o Id {id} não encontrado.");
            }

            return await context.Contacts.FindAsync(id);


        }

        public async Task<List<Contact>> ListarAsync()
        {
            return await context.Contacts.ToListAsync();
        }

        
        
    }
}
