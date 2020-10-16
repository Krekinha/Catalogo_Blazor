using Catalogo_Blazor.Server.Context;
using Catalogo_Blazor.Server.Utils;
using Catalogo_Blazor.Shared.Models;
using Catalogo_Blazor.Shared.Models.Recursos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo_Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Produtos
        // Retorna uma lista de Produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos([FromQuery] Paginacao paginacao,
            [FromQuery] string nome)
        {
            var queryable = _context.Produtos.AsQueryable();

            //Filtra por nome
            if (!string.IsNullOrEmpty(nome))
            {
                queryable = queryable.Where(x => x.Nome.Contains(nome));
            }

            await HttpContext.InserirParametroEmPageResponse(queryable, paginacao.quantidadePorPagina);

            return await queryable.Paginar(paginacao).ToListAsync();
        }

        // GET: api/Produtos/5
        // Busca e retorna uma Produto com base em um "id"
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        // PUT: api/Produtos/5
        // Atualiza uma Produto existente
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Produtos
        // Cria uma nova Produto
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            //retorna a produto criada
            return CreatedAtAction("GetProduto", new { id = produto.ProdutoId }, produto);
        }

        // DELETE: api/Produtos/5
        // Busca e exclui uma Produto com base em um "id"
        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> DeleteProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.ProdutoId == id);
        }
    }
}
