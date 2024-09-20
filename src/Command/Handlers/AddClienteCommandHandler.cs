using Repositories;
using Contract;

namespace Command
{
    public class AddClienteCommandHandler
    {
        private readonly IClienteCommandRepository _clienteRepository;
        private readonly IClienteQueryRepository _clienteQueryRepository; // Repositório de leitura (MongoDB)

        public AddClienteCommandHandler(IClienteCommandRepository clienteRepository, 
                                        IClienteQueryRepository clienteQueryRepository)
        {
            _clienteRepository = clienteRepository;
            _clienteQueryRepository = clienteQueryRepository;
        }

        public async Task<ClienteCommandResult> Handle(ClienteCommand input)
        {
            // Adiciona no MySQL
            var cliente = new CadastroCliente.Cliente(input.NomeEmpresa, input.Porte);
            await _clienteRepository.AddAsync(cliente);
            
            // Sincroniza com MongoDB
            await _clienteQueryRepository.AddToMongoAsync(cliente);

            return new ClienteCommandResult
            {
                Id = cliente.Id,
                NomeEmpresa = cliente.NomeEmpresa,
                Porte = cliente.Porte
            };
        }
    }
}