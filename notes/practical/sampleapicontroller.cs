using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")] // This makes the URL: api/products
public class ProductsController : ControllerBase
{
	private static List<Product> _products = new();
	// GET: api/products
	[HttpGet]
	public ActionResult<IEnumerable<Product>> Get()
	{
		return Ok(_products); // Returns 200 OK
	}

	// GET: api/products/5
	[HttpGet("{id}")]
	public ActionResult<Product> GetById(int id)
	{
		var product = _products.FirstOrDefault(p => p.Id == id);
		if (product == null)
		{
			return NotFound(); // Returns 404
		}

		return Ok(product);
	}

	// POST: api/products
	[HttpPost]
	public IActionResult Create(Product product)
	{
		_products.Add(product);
		// Returns 201 Created with the location of the new resource
		return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
	}
}

public record Product(int Id, string Name, decimal Price);