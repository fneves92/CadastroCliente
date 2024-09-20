using CadastroCliente;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Repository
{
    public class ClienteQueryRepository : IClienteMongoRepository
    {
        private readonly IMongoCollection<Cliente> _clientesCollection;

        public ClienteQueryRepository(IMongoDatabase database)
        {
            _clientesCollection = database.GetCollection<Cliente>("Clientes");
        }

        public Task AddToMongoAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFromMongoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _clientesCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            var filter = Builders<Cliente>.Filter.Eq(c => c.Id, id);
            return await _clientesCollection.Find(filter).FirstOrDefaultAsync();
        }

        public Task UpdateInMongoAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}