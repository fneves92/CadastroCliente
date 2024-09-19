using CadastroCliente;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task Handle(Cliente cliente)
        {
            // Adiciona no MySQL
            await _clienteRepository.AddAsync(cliente);
            
            // Sincroniza com MongoDB
            await _clienteQueryRepository.AddToMongoAsync(cliente);
        }
    }
}