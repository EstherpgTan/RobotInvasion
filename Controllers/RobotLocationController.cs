using Microsoft.AspNetCore.Mvc;
using RobotInvasion2.Model;
using RobotInvasion2.Services;


namespace RobotInvasion2.Controllers;

[ApiController]
[Route("[controller]")]
public class RobotLocationController : ControllerBase
{
    private readonly ILogger<RobotLocationController> _logger;
    private readonly LocationService _service;
    private readonly LocationContext _context;

    public RobotLocationController(LocationContext context, LocationService service, ILogger<RobotLocationController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpPost(Name = "RobotLocation")]
    public async Task<string> Post(Location location)
    {
        _logger.Log(LogLevel.Information, new EventId(), null, "Finding the nearest water source to" + location.display_name, null);
        string NearestWaterSource = await _service.GetNearestWaterSource(location);
        JsonSerializer.Serialize(NearestWaterSource);
        Class[] x = JsonSerializer.Deserialize<Class>(NearestWaterSource);
        return x[0].display_name;


            return _context.Locations;
    }
    [HttpPost(Name = "RobotLocation")]

    public void Post(Location location)
    {
        _context.Locations.Add(location);
        _context.SaveChanges();
    }
}



