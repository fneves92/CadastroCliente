using CadastroCliente;
using Contract;

namespace Command
{
    public class AddClienteCommandHandler
    {
        private readonly IClienteService _clienteService;

        public AddClienteCommandHandler(IClienteService clienteService)                                      
        {
            _clienteService = clienteService;
        }

        public async Task<ClienteCommandResult> Handle(ClienteCommand input)
        {            
            var cliente = new CadastroCliente.Cliente();
            cliente.NomeEmpresa = input.NomeEmpresa;
            cliente.Porte = input.Porte;
            await _clienteService.AddClienteAsync(cliente);        

            return new ClienteCommandResult
            {
                Id = cliente.Id,
                NomeEmpresa = cliente.NomeEmpresa,
                Porte = cliente.Porte
            };
        }
    }
}