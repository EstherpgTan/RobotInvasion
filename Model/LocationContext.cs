using System;
using Microsoft.EntityFrameworkCore;

namespace RobotInvasion2.Model
{
	public class LocationContext : DbContext
	{
		public LocationContext(DbContextOptions<LocationContext> options):base(options)
		{
		}
		public DbSet<Location> Locations { get; set; }
	}
}

