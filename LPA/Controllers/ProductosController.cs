using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LPA.Context;
using LPA.Models;
using LPA.Handlers;

namespace LPA.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductosDbContext _context;
        private readonly ImageHandler _imageHandler;
        public ProductosController(ProductosDbContext context)
        {
            _context = context;
            _imageHandler = new ImageHandler();
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // PUT: api/Productos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, [FromForm] Producto producto, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != producto.ProductId)
            {
                return BadRequest();
            }
            if (file != null)
            {
                try
                {
                    var actionResult = await _imageHandler.UploadImage(file);
                    var okResult = actionResult as ObjectResult;

                    if (okResult.Value.ToString() == "Invalid image file")
                    {
                        return BadRequest(new JsonResult(okResult.Value));
                    }
                    else
                    {
                        var path = "/images/products/" + okResult.Value.ToString();
                        producto.ProductImagePath = path;

                    }
                }
                catch (Exception)
                {
                    return BadRequest(new JsonResult("ERROR"));
                }
            }
            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest();
                }
            }
            return Ok(producto);
        }

        // POST: api/Productos
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto([FromForm] Producto product, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var actionResult = await _imageHandler.UploadImage(file);
                var okResult = actionResult as ObjectResult;
                if (okResult.Value.ToString() == "Invalid image file")
                {
                    return BadRequest(new JsonResult(okResult.Value));
                }
                else
                {
                    var path = "/images/products/" + okResult.Value.ToString();
                    product.ProductImagePath = path;
                    _context.Productos.Add(product);

                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
                }
            }
            catch (Exception)
            {
                return BadRequest(new JsonResult("ERROR"));
            }
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Producto>> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return producto;
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.ProductId == id);
        }
    }
}
