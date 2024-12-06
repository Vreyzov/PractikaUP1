using EquipmentRentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly EquipmentRentContext _context;

    public ClientsController(EquipmentRentContext context)
    {
        _context = context;
    }

    // GET: api/clients
    /// <summary>
    /// Получить список всех клиентов.
    /// </summary>
    /// <returns>Список клиентов</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> GetAllClients()
    {
        var clients = await _context.Clients.ToListAsync();

        if (clients == null || !clients.Any())
        {
            return NotFound("Клиенты не найдены");
        }

        return Ok(clients);  // Возвращаем 200 OK с данными клиентов
    }

    // GET: api/clients/{id}
    /// <summary>
    /// Получить клиента по ID.
    /// </summary>
    /// <param name="id">ID клиента</param>
    /// <returns>Клиент с указанным ID</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> GetClientById(int id)
    {
        var client = await _context.Clients.FindAsync(id);

        if (client == null)
        {
            return NotFound();  // Возвращаем 404, если клиент не найден
        }

        return Ok(client);  // Возвращаем 200 OK с данными клиента
    }

    // POST: api/clients
    /// <summary>
    /// Создать нового клиента.
    /// </summary>
    /// <param name="client">Данные клиента для создания</param>
    /// <returns>Созданный клиент</returns>
    [HttpPost]
    public async Task<IActionResult> CreateClient(Client client)
    {
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetClientById), new { id = client.ClientId }, client);  // Возвращаем 201 Created
    }

    // PUT: api/clients/{id}
    /// <summary>
    /// Обновить данные клиента по ID.
    /// </summary>
    /// <param name="id">ID клиента</param>
    /// <param name="client">Обновленные данные клиента</param>
    /// <returns>Результат выполнения операции</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClient(int id, [FromBody] Client client)
    {
        if (id != client.ClientId)
        {
            // Возвращаем ошибку, если ID в URL не совпадает с ID в теле запроса
            return BadRequest("ID в маршруте не совпадает с ID в теле запроса.");
        }

        _context.Entry(client).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Clients.Any(e => e.ClientId == id))
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

    // DELETE: api/clients/{id}
    /// <summary>
    /// Удалить клиента по ID.
    /// </summary>
    /// <param name="id">ID клиента</param>
    /// <returns>Результат выполнения операции</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null)
        {
            return NotFound();  // Возвращаем 404, если клиент не найден
        }

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();

        return NoContent();  // Возвращаем 204 No Content, если удаление прошло успешно
    }

    // Проверка, существует ли клиент с указанным ID
    private bool ClientExists(int id)
    {
        return _context.Clients.Any(e => e.ClientId == id);  // Проверка, существует ли клиент с данным ID
    }
}
