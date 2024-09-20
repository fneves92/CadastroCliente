using CadastroCliente;

namespace Command
{
    public class DeleteClienteCommandHandler
    {
        private readonly IClienteService _clienteService;
        public DeleteClienteCommandHandler(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task Handle(int id)
        {
            await _clienteService.DeleteClienteAsync(id);
        }
    }
}