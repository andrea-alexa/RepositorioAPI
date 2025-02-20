using ApiBackend.DTOs;
using ApiBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        public ProductoContext _productoContext;

        public ProductoController(ProductoContext context)
        {
            _productoContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> ObtenerProducto()
        {
            var productos = await _productoContext.Productos.ToListAsync();
            var productosDTO = productos.Select(p => new ProductoDTO
            {
                id = p.Id,
                nombre = p.Nombre,
                precio = p.Precio,
                stock = p.Stock
            }).ToList();

            return Ok(productosDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDTO>> ObtenerPorId(int id)
        {
            var producto = await _productoContext.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            var productoDTO = new ProductoDTO
            {
                id = producto.Id,
                nombre = producto.Nombre,
                precio = producto.Precio,
                stock = producto.Stock
            };
            return Ok(productoDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CrearProducto(ProductoInsertDTO productoInsertDTO)
        {
            var producto = new Productos()
            {
                Nombre = productoInsertDTO.nombre,
                Precio = productoInsertDTO.precio,
                Stock = productoInsertDTO.stock
            };
            await _productoContext.Productos.AddAsync(producto);
            await _productoContext.SaveChangesAsync();

            var productoDTO = new ProductoDTO
            {
                id = producto.Id,
                nombre = productoInsertDTO.nombre,
                precio = productoInsertDTO.precio,
                stock = productoInsertDTO.stock
            };
            return CreatedAtAction(nameof(ObtenerPorId), new { id = producto.Id}, productoDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarProducto(int id, ProductoDTO ProductoUpdateDTO)
        {
            var producto = await _productoContext.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            producto.Nombre = ProductoUpdateDTO.nombre;
            producto.Precio = ProductoUpdateDTO.precio;
            producto.Stock = ProductoUpdateDTO.stock;
            await _productoContext.SaveChangesAsync();

            var productoDTO = new ProductoDTO
            {
                id = producto.Id,
                nombre = producto.Nombre,
                precio = producto.Precio,
                stock = producto.Stock
            };
            return Ok(productoDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarProducto(int id)
        {
            var producto = await _productoContext.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            _productoContext.Productos.Remove(producto);
            await _productoContext.SaveChangesAsync();
            return Ok();
        }
    }
}
