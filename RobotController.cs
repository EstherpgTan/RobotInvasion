using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RobotInvasion.Models;

namespace RobotInvasion.Controllers;

public class RobotController : Controller
{
    private readonly ILogger<RobotController> _logger;
    private readonly LocationService _service;

    public RobotController(LocationService service, ILogger<RobotController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet(Name = "RobotLocated")]
    
    public string Get()
    {
        return "test";
    }
    [HttpPost(Name = "RobotLocated")]
    
    public async Task<string> Post(Location location, CancellationToken token)
    {
        _logger.Log(LogLevel.Information, new EventId, null, "Location name sent" + location.Name, null);

        var x = await _service.GetNearestBodyOfWater(location, token);
        return $"The nearest body of water to {location.Name} is {x}";
    }
        
   }


