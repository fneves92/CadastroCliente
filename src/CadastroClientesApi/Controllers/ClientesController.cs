using Microsoft.AspNetCore.Mvc;
using Command;
using Command.Handlers;
using Contract;
using Query.Handlers;

namespace CadastroClientesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly GetAllClientesQueryHandler _getAllClientesQueryHandler;
        private readonly GetClienteByIdQueryHandler _getClienteByIdQueryHandler;
        private readonly AddClienteCommandHandler _addClienteHandler;
        private readonly UpdateClienteCommandHandler _updateClienteHandler;
        private readonly DeleteClienteCommandHandler _deleteClienteHandler;

        public ClientesController(AddClienteCommandHandler addClienteHandler,
                                  UpdateClienteCommandHandler updateClienteHandler,
                                  DeleteClienteCommandHandler deleteClienteHandler,
                                  GetClienteByIdQueryHandler getClienteByIdQueryHandler,
                                  GetAllClientesQueryHandler getAllClientesQueryHandler)
        {
            _addClienteHandler = addClienteHandler;
            _updateClienteHandler = updateClienteHandler;
            _deleteClienteHandler = deleteClienteHandler;
            _getClienteByIdQueryHandler = getClienteByIdQueryHandler;
            _getAllClientesQueryHandler = getAllClientesQueryHandler;
        }

        // GET: api/clientes (Consultas)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteCommandResult>>> GetClientes()
        {
            var clientes = await _getAllClientesQueryHandler.Handle();
            return Ok(clientes);
        }

        // GET: api/clientes/{id} (Consultas)
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteCommandResult>> GetCliente(int id)
        {
            var cliente = await _getClienteByIdQueryHandler.Handle(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // POST: api/clientes (Comandos - Adicionar)
        [HttpPost]
        public async Task<ActionResult> PostCliente(ClienteCommand cliente)
        {
            var result = await _addClienteHandler.Handle(cliente); // Usando o Command Handler
            return CreatedAtAction(nameof(GetCliente), new { id = result.Id }, cliente);
        }

        // PUT: api/clientes/{id} (Comandos - Atualizar)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteCommand cliente)
        {
            await _updateClienteHandler.Handle(id,cliente); // Usando o Command Handler
            return NoContent();
        }

        // DELETE: api/clientes/{id} (Comandos - Deletar)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            await _deleteClienteHandler.Handle(id); // Usando o Command Handler
            return NoContent();
        }
    }
}
