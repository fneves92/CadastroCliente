using CadastroCliente;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Handlers
{
    public class GetClienteByIdQueryHandler
    {
        private readonly IClienteQueryRepository _clienteQueryRepository;

        public GetClienteByIdQueryHandler(IClienteQueryRepository clienteQueryRepository)
        {
            _clienteQueryRepository = clienteQueryRepository;
        }

        public async Task<Cliente?> Handle(int id)
        {
            return await _clienteQueryRepository.GetByIdAsync(id);
        }
    }
}