using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class DeleteClienteCommandHandler
    {
        private readonly IClienteCommandRepository _clienteRepository;
        private readonly IClienteQueryRepository _clienteQueryRepository; // Repositório de leitura (MongoDB)

        public DeleteClienteCommandHandler(IClienteCommandRepository clienteRepository, 
                                           IClienteQueryRepository clienteQueryRepository)
        {
            _clienteRepository = clienteRepository;
            _clienteQueryRepository = clienteQueryRepository;
        }

        public async Task Handle(int id)
        {
            // Remove do MySQL
            await _clienteRepository.DeleteAsync(id);
            
            // Remove do MongoDB
            await _clienteQueryRepository.DeleteFromMongoAsync(id);
        }
    }
}