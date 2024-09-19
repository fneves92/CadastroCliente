using CadastroCliente;
using Repositories;

namespace Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteCommandRepository _clienteCommandRepository;
        private readonly IClienteQueryRepository _clienteQueryRepository;

        public ClienteService(IClienteCommandRepository clienteCommandRepository, IClienteQueryRepository clienteQueryRepository)
        {
            _clienteCommandRepository = clienteCommandRepository;
            _clienteQueryRepository = clienteQueryRepository;
        }

        // Consultas (Leitura) em MongoDB
        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            return await _clienteQueryRepository.GetAllAsync(); // MongoDB
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _clienteQueryRepository.GetByIdAsync(id); // MongoDB
        }

        // Comandos (Escrita) em MySQL + Projeção para MongoDB
        public async Task AddClienteAsync(Cliente cliente)
        {
            await _clienteCommandRepository.AddAsync(cliente); // MySQL
            await _clienteQueryRepository.AddToMongoAsync(cliente); // MongoDB - Sincronizar com o MongoDB
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            await _clienteCommandRepository.UpdateAsync(cliente); // MySQL
            await _clienteQueryRepository.UpdateInMongoAsync(cliente); // MongoDB - Sincronizar com o MongoDB
        }

        public async Task DeleteClienteAsync(int id)
        {
            await _clienteCommandRepository.DeleteAsync(id); // MySQL
            await _clienteQueryRepository.DeleteFromMongoAsync(id); // MongoDB - Sincronizar com o MongoDB
        }
    }
}
