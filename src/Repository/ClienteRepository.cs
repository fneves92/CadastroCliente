using CadastroCliente;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Infrastructure.MongoDB;
using Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public class ClienteQueryRepository : IClienteQueryRepository
    {
        private readonly IMongoCollection<Cliente> _clientesCollection;

        public ClienteQueryRepository(IMongoDatabase database)
        {
            _clientesCollection = database.GetCollection<Cliente>("Clientes");
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

        Task IClienteQueryRepository.AddToMongoAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        Task IClienteQueryRepository.DeleteFromMongoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Cliente>> IClienteQueryRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Cliente?> IClienteQueryRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IClienteQueryRepository.UpdateInMongoAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}