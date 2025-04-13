using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIMS.Data;
using SIMS.Models;

[Route("api/[controller]")]
[ApiController]
public class InventoryController : ControllerBase
{
    private readonly InventoryContext _context;

    public InventoryController(InventoryContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<InventoryItem>>> GetItems()
    {
        try
        {
            // Check if the context is null
            if (_context == null)
            {
                return StatusCode(500, "Database context is not initialized.");
            }

            // Fetch items from the database
            var items = await _context.Items.ToListAsync();

            // If no items found, return a 404 status
            if (items == null || items.Count == 0)
            {
                return NotFound("No items found in the inventory.");
            }

            return Ok(items);  // Return fetched items
        }
        catch (Exception ex)
        {
            // Return a 500 status code with the error message
            return StatusCode(500, $"Error fetching items: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<InventoryItem>> GetItem(int id)
    {
        try
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error fetching item: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<InventoryItem>> CreateItem(InventoryItem item)
    {
        try
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error creating item: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem(int id, InventoryItem item)
    {
        try
        {
            if (id != item.Id)
            {
                return BadRequest("Item ID mismatch");
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error updating item: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        try
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error deleting item: {ex.Message}");
        }
    }
}
