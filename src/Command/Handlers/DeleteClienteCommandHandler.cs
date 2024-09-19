using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Handlers
{
    public class DeleteClienteCommandHandler
    {
        private readonly IClienteCommandRepository _clienteRepository;

        public DeleteClienteCommandHandler(IClienteCommandRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task Handle(int id)
        {
            await _clienteRepository.DeleteAsync(id);
        }
    }
}