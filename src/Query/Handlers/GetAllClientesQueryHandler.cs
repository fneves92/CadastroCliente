using CadastroCliente;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Handlers
{
    public class GetAllClientesQueryHandler
    {
        private readonly IClienteQueryRepository _clienteQueryRepository;

        public GetAllClientesQueryHandler(IClienteQueryRepository clienteQueryRepository)
        {
            _clienteQueryRepository = clienteQueryRepository;
        }

        public async Task<IEnumerable<Cliente>> Handle()
        {
            return await _clienteQueryRepository.GetAllAsync();
        }
    }
}