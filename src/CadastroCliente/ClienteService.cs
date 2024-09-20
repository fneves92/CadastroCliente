namespace CadastroCliente
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteCommandRepository _clienteCommandRepository;
        private readonly IClienteMongoRepository _clienteMongoRepository;

        public ClienteService(IClienteCommandRepository clienteCommandRepository, IClienteMongoRepository clienteQueryRepository)
        {
            _clienteCommandRepository = clienteCommandRepository;
            _clienteMongoRepository = clienteQueryRepository;
        }
        public async Task AddClienteAsync(Cliente cliente)
        {
            await _clienteCommandRepository.AddAsync(cliente); 
            await _clienteMongoRepository.AddToMongoAsync(cliente); 
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            await _clienteCommandRepository.UpdateAsync(cliente);
            await _clienteMongoRepository.UpdateInMongoAsync(cliente);
        }

        public async Task DeleteClienteAsync(int id)
        {
            await _clienteCommandRepository.DeleteAsync(id); 
            await _clienteMongoRepository.DeleteFromMongoAsync(id);
        }
    }
}
