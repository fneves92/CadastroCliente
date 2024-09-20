using Contract;
using Repositories;

namespace Command.Handlers
{
    public class UpdateClienteCommandHandler
    {
        private readonly IClienteCommandRepository _clienteRepository;
        private readonly IClienteQueryRepository _clienteQueryRepository; // Repositório de leitura (MongoDB)

        public UpdateClienteCommandHandler(IClienteCommandRepository clienteRepository, 
                                           IClienteQueryRepository clienteQueryRepository)
        {
            _clienteRepository = clienteRepository;
            _clienteQueryRepository = clienteQueryRepository;
        }

        public async Task<ClienteCommandResult> Handle(ClienteCommand input)
        {
            // Atualiza no MySQL
            var cliente = new CadastroCliente.Cliente(input.NomeEmpresa, input.Porte);
            await _clienteRepository.UpdateAsync(cliente);
            
            // Sincroniza com MongoDB
            await _clienteQueryRepository.UpdateInMongoAsync(cliente);

            return new ClienteCommandResult()
            {
                Id = cliente.Id,
                NomeEmpresa = cliente.NomeEmpresa,
                Porte = cliente.Porte
            };
        }
    }
}