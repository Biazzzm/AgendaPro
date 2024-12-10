using AgendaPro.Api.Models;

namespace AgendaPro.Api.Repositories
{
    public interface IContactRepository
    {
        Task DeletarAsync(int id);

        Task CriarAsync(Contact contato);

        Task AlterarAsync(Contact contato);

        Task<List<Contact>> ListarAsync();

        Task<Contact?> GetAsync(int id);

    }
}
