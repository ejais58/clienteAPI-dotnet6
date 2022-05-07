using ClienteAPI.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClienteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly DataContext context;

        public ClienteController(DataContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            return Ok(await this.context.Clientes.ToListAsync());
        }
        [HttpGet ("{id}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var dbcliente =await this.context.Clientes.FindAsync(id);
            if (dbcliente == null)
            {
                return BadRequest("Cliente no encontrado");
            }
            return Ok(dbcliente);
        }

        [HttpPost]
        public async Task<ActionResult<List<Cliente>>> AddCliente( Cliente cliente)
        {
            this.context.Clientes.Add(cliente);
            await this.context.SaveChangesAsync();
            return Ok(await this.context.Clientes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Cliente>>> UpdateCliente(Cliente item)
        {
            var dbcliente = await this.context.Clientes.FindAsync(item.Id);
            if (dbcliente == null)
            {
                return BadRequest("Cliente no encontrado");
            }
            dbcliente.Nombre = item.Nombre;
            dbcliente.Apellido = item.Apellido;
            dbcliente.Edad = item.Edad;

            await this.context.SaveChangesAsync();
            return Ok(await this.context.Clientes.ToListAsync());
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult<List<Cliente>>> Delete(int id)
        {
            var dbcliente = await this.context.Clientes.FindAsync(id);
            if (dbcliente == null)
            {
                return BadRequest("Cliente no encontrado");
            }
            this.context.Clientes.Remove(dbcliente);
            await this.context.SaveChangesAsync();
            return Ok(await this.context.Clientes.ToListAsync());
        }


    }
}
