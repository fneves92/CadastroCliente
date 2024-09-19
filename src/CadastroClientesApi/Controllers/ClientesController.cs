using CadastroCliente;
using Microsoft.AspNetCore.Mvc;
using Services;
using Command;

namespace CadastroClientesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly AddClienteCommandHandler _addClienteHandler;
        private readonly UpdateClienteCommandHandler _updateClienteHandler;
        private readonly DeleteClienteCommandHandler _deleteClienteHandler;

        public ClientesController(IClienteService clienteService, 
                                  AddClienteCommandHandler addClienteHandler,
                                  UpdateClienteCommandHandler updateClienteHandler,
                                  DeleteClienteCommandHandler deleteClienteHandler)
        {
            _clienteService = clienteService;
            _addClienteHandler = addClienteHandler;
            _updateClienteHandler = updateClienteHandler;
            _deleteClienteHandler = deleteClienteHandler;
        }

        // GET: api/clientes (Consultas)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _clienteService.GetAllClientesAsync();
            return Ok(clientes);
        }

        // GET: api/clientes/{id} (Consultas)
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // POST: api/clientes (Comandos - Adicionar)
        [HttpPost]
        public async Task<ActionResult> PostCliente(Cliente cliente)
        {
            await _addClienteHandler.Handle(cliente); // Usando o Command Handler
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
        }

        // PUT: api/clientes/{id} (Comandos - Atualizar)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            await _updateClienteHandler.Handle(cliente); // Usando o Command Handler
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
