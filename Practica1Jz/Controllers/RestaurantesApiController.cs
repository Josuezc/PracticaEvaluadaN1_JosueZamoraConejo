using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica1Jz.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;

namespace Practica1Jz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantesApiController : ControllerBase
    {
        private readonly RestauranteContext _context;

        public RestaurantesApiController(RestauranteContext context)
        {
            _context = context;
        }

        // GET: api/RestaurantesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurante>>> GetRestaurante()
        {
            return await _context.Restaurante.ToListAsync();
        }

        // GET: api/RestaurantesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurante>> GetRestaurante(int id)
        {
            var restaurante = await _context.Restaurante.FindAsync(id);

            if (restaurante == null)
            {
                return NotFound();
            }

            return restaurante;
        }

        // PUT: api/RestaurantesApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurante(int id, Restaurante restaurante)
        {
            if (id != restaurante.Id)
            {
                return BadRequest();
            }

            _context.Entry(restaurante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestauranteExists(id))
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

        // POST: api/RestaurantesApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Restaurante>> PostRestaurante(Restaurante restaurante)
        {
            _context.Restaurante.Add(restaurante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurante", new { id = restaurante.Id }, restaurante);
        }

        // DELETE: api/RestaurantesApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurante(int id)
        {
            var restaurante = await _context.Restaurante.FindAsync(id);
            if (restaurante == null)
            {
                return NotFound();
            }

            _context.Restaurante.Remove(restaurante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RestauranteExists(int id)
        {
            return _context.Restaurante.Any(e => e.Id == id);
        }
    }
public static class RestauranteEndpoints
{
	public static void MapRestauranteEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Restaurante").WithTags(nameof(Restaurante));
        group.MapGet("/", () =>
        {
            return new [] { new Restaurante() };
        })
        .WithName("GetAllRestaurantes")
        .WithOpenApi();
        group.MapGet("/{id}", (int id) =>
        {
            //return new Restaurante { ID = id };
        })
        .WithName("GetRestauranteById")
        .WithOpenApi();
        group.MapPut("/{id}", (int id, Restaurante input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateRestaurante")
        .WithOpenApi();
        group.MapPost("/", (Restaurante model) =>
        {
            //return TypedResults.Created($"/api/Restaurantes/{model.ID}", model);
        })
        .WithName("CreateRestaurante")
        .WithOpenApi();
        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new Restaurante { ID = id });
        })
        .WithName("DeleteRestaurante")
        .WithOpenApi();
    }
}}
