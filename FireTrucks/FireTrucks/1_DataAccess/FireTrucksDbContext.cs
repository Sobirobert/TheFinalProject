
using FireTrucks._1_DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FireTrucks._1_DataAccess;

public class FireTrucksDbContext : DbContext
{
    public FireTrucksDbContext(DbContextOptions<FireTrucksDbContext> options)
       : base(options)
    {
    }
    public DbSet<EmergencyVehicle> EmergencyCars { get; set; }
    public DbSet<FirefightingVehicle> FirefightingVehicles { get; set; }
    public DbSet<Trailer> Trailers { get; set; }
}
