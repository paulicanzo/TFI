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
using System.IO;

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
        public async Task<IActionResult> PutProducto(int id)
        {   
            if (!ProductoExists(id)) return BadRequest();
            
            var producto = await _context.Productos.FindAsync(id);

            var valiTitulo = Request.Form.TryGetValue("titulo", out var titulo);
            var valiPrecio = Request.Form.TryGetValue("precio", out var precio);
            precio = precio.ToString().Replace(".", ",");
            var valiDescr = Request.Form.TryGetValue("descripcion", out var descripcion);            
            var valiPrecioP = Decimal.TryParse(precio.ToString(), out var precioD);

            if (!valiTitulo|| !valiPrecio  || !valiDescr || !valiPrecioP)
            {
                return BadRequest(new JsonResult("ERROR VALIDACION"));
            }
            producto.ProductName = titulo;
            producto.ProductPrice = precioD;
            producto.ProductDescription = descripcion;

            

            if (Request.Form.Files.Count != 0)
            {
                var file = Request.Form.Files.First();
                if (file != null)
                {
                    try
                    {
                        var actionResult = await _imageHandler.UploadImage(file);
                        var okResult = actionResult as ObjectResult;

                        if (okResult.Value.ToString() == "Tipo de imagen invalido")
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
            }
            _context.Productos.Update(producto);

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
        public async Task<ActionResult<Producto>> PostProducto()
        {
            var producto = new Producto();

            if (!Request.Form.TryGetValue("titulo", out var titulo) || !Request.Form.TryGetValue("precio", out var precio) ||
                !Request.Form.TryGetValue("descripcion", out var descripcion) || !Decimal.TryParse(precio.ToString().Replace(".", ","), out var precioD))
            {
                return BadRequest(new JsonResult("ERROR VALIDACION"));
            }
            producto.ProductName = titulo;
            producto.ProductPrice = precioD;
            producto.ProductDescription = descripcion;

            //Usando ENTITY FRAMEWORK EN MEMORIA NECESITAMOS NOSOTROS GENERAR EL SIGUIENTE PRODUCT ID
            //En las proximas versiones lo van a implementar
            var newID = _context.Productos.Select(x => x.ProductId).Max() + 1;
            producto.ProductId = newID;

            if (Request.Form.Files.Count != 0)
            {
                var file = Request.Form.Files.First();
                if (file != null)
                {
                    try
                    {
                        var actionResult = await _imageHandler.UploadImage(file);
                        var okResult = actionResult as ObjectResult;

                        if (okResult.Value.ToString() == "Tipo de imagen invalido")
                        {
                            return BadRequest(new JsonResult(okResult.Value));
                        }
                        else
                        {
                            var path = "/images/products/" + okResult.Value.ToString();

                            //Eliminamos la imagen anterior
                            string pathFile = Directory.GetCurrentDirectory() + "/wwwroot" + producto.ProductImagePath;
                            if (System.IO.File.Exists(pathFile))
                            {
                                System.IO.File.Delete(pathFile);
                            }

                            producto.ProductImagePath = path;
                        }
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(new JsonResult("ERROR"));
                    }
                }
                else
                {
                    return BadRequest(new JsonResult("IMAGEN FALTANTE"));
                }
            }
            else
            {
                return BadRequest(new JsonResult("IMAGEN FALTANTE"));
            }

            try
            {
                _context.Productos.Add(producto);

                await _context.SaveChangesAsync();

                return Ok(producto);
            }
            catch (Exception ex)
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
            try
            {
                string pathFile = Directory.GetCurrentDirectory()+ "/wwwroot"+producto.ProductImagePath;
                if (System.IO.File.Exists(pathFile))
                {
                    System.IO.File.Delete(pathFile);
                }
            }
            catch (Exception)
            {
                return BadRequest();
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
