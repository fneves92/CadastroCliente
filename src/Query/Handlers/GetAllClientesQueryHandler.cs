using CadastroCliente;

namespace Query.Handlers
{
    public class GetAllClientesQueryHandler
    {
        private readonly IClienteMongoRepository _clienteMongoRepository;

        public GetAllClientesQueryHandler(IClienteMongoRepository clienteQueryRepository)
        {
            _clienteMongoRepository = clienteQueryRepository;
        }

        public async Task<IEnumerable<Cliente>> Handle()
        {
            return await _clienteMongoRepository.GetAllAsync();
        }
    }
}