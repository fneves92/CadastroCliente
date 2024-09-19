using CadastroCliente;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Handlers
{
    public class AddClienteCommandHandler
    {
        private readonly IClienteCommandRepository _clienteRepository;

        public AddClienteCommandHandler(IClienteCommandRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task Handle(Cliente cliente)
        {
            await _clienteRepository.AddAsync(cliente);
        }
    }
}