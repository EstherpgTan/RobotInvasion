using System.Text.Json;
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

    public RobotLocationController(LocationService service, ILogger<RobotLocationController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpPost(Name = "RobotLocation")]
    public async Task<string> Post(Location location)
    {
        _logger.Log(LogLevel.Information, new EventId(), null, "Logged:" + location.displayName, null);

        string NearestWaterSource = await _service.GetNearestWaterSource(location);

        JsonSerializer.Serialize(NearestWaterSource);

        WaterSourceLocation[] WaterSource = JsonSerializer.Deserialize<WaterSourceLocation[]>(NearestWaterSource);
        return $"Closest water source to: {location.displayName} is {WaterSource[0].display_name}";
        
    }
}
    



