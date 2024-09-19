using CadastroCliente;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
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

        public async Task Handle(Cliente cliente)
        {
            // Atualiza no MySQL
            await _clienteRepository.UpdateAsync(cliente);
            
            // Sincroniza com MongoDB
            await _clienteQueryRepository.UpdateInMongoAsync(cliente);
        }
    }
}