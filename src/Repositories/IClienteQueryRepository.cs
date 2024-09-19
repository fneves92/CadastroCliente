using CadastroCliente;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IClienteQueryRepository
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(int id);
        Task AddToMongoAsync(Cliente cliente);
        Task UpdateInMongoAsync(Cliente cliente);
        Task DeleteFromMongoAsync(int id);
    }
}