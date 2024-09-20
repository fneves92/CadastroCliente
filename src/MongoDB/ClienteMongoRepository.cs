using CadastroCliente;
using MongoDB.Driver;

namespace Infrastructure.MongoDB
{
    public class ClienteMongoRepository : IClienteMongoRepository
    {
        private readonly IMongoCollection<Cliente> _clientesCollection;

        public ClienteMongoRepository(IMongoDatabase database)
        {
            _clientesCollection = database.GetCollection<Cliente>("Clientes");
        }

        public async Task AddToMongoAsync(Cliente cliente)
        {
            await _clientesCollection.InsertOneAsync(cliente);
        }

        public async Task UpdateInMongoAsync(Cliente cliente)
        {
            var filter = Builders<Cliente>.Filter.Eq(c => c.Id, cliente.Id);
            await _clientesCollection.ReplaceOneAsync(filter, cliente);
        }

        public async Task DeleteFromMongoAsync(int id)
        {
            var filter = Builders<Cliente>.Filter.Eq(c => c.Id, id);
            await _clientesCollection.DeleteOneAsync(filter);
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
    }
}