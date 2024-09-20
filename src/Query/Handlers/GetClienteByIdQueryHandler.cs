using CadastroCliente;

namespace Query.Handlers
{
    public class GetClienteByIdQueryHandler
    {
        private readonly IClienteMongoRepository _clienteMongoRepository;

        public GetClienteByIdQueryHandler(IClienteMongoRepository clienteQueryRepository)
        {
            _clienteMongoRepository = clienteQueryRepository;
        }

        public async Task<Cliente?> Handle(int id)
        {
            return await _clienteMongoRepository.GetByIdAsync(id);
        }
    }
}