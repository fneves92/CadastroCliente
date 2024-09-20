using CadastroCliente;
using Contract;

namespace Command.Handlers
{
    public class UpdateClienteCommandHandler
    {
        private readonly IClienteService _clienteService;
        public UpdateClienteCommandHandler(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<ClienteCommandResult> Handle(int id, ClienteCommand input)
        {
            var cliente = new CadastroCliente.Cliente();
            cliente.Id = id;
            cliente.NomeEmpresa = input.NomeEmpresa;
            cliente.Porte = input.Porte;
            await _clienteService.UpdateClienteAsync(cliente);
            
            return new ClienteCommandResult()
            {
                Id = cliente.Id,
                NomeEmpresa = cliente.NomeEmpresa,
                Porte = cliente.Porte
            };
        }
    }
}