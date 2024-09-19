using CadastroCliente;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Handlers
{
    public class UpdateClienteCommandHandler
    {
        private readonly IClienteCommandRepository _clienteRepository;

        public UpdateClienteCommandHandler(IClienteCommandRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task Handle(Cliente cliente)
        {
            await _clienteRepository.UpdateAsync(cliente);
        }
    }
}