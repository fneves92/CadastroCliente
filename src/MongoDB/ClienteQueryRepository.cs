using CadastroCliente;
using MongoDB.Driver;
using Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.MongoDB
{
    public class ClienteQueryRepository : IClienteQueryRepository
    {
        private readonly IMongoCollection<Cliente> _clientesCollection;

        public ClienteQueryRepository(IMongoDatabase database)
        {
            _clientesCollection = database.GetCollection<Cliente>("Clientes");
        }

        // Implementação para adicionar cliente no MongoDB
        public async Task AddToMongoAsync(Cliente cliente)
        {
            await _clientesCollection.InsertOneAsync(cliente);
        }

        // Implementação para atualizar cliente no MongoDB
        public async Task UpdateInMongoAsync(Cliente cliente)
        {
            var filter = Builders<Cliente>.Filter.Eq(c => c.Id, cliente.Id);
            await _clientesCollection.ReplaceOneAsync(filter, cliente);
        }

        // Implementação para deletar cliente do MongoDB
        public async Task DeleteFromMongoAsync(int id)
        {
            var filter = Builders<Cliente>.Filter.Eq(c => c.Id, id);
            await _clientesCollection.DeleteOneAsync(filter);
        }

        // Implementação para listar todos os clientes
        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _clientesCollection.Find(_ => true).ToListAsync();
        }

        // Implementação para buscar cliente por ID
        public async Task<Cliente?> GetByIdAsync(int id)
        {
            var filter = Builders<Cliente>.Filter.Eq(c => c.Id, id);
            return await _clientesCollection.Find(filter).FirstOrDefaultAsync();
        }
    }
}