using Microsoft.EntityFrameworkCore;
using SensorsProject.Models.DataModels;
using SensorsProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<TempSensor> TempSensors { get; set; }
    public DbSet<PhSensor> PhSensor { get; set; }
    public DbSet<TempData> TempData { get; set; }
    public DbSet<PhData> PhData { get; set; }
    public DbSet<ECSensor> ECSensors { get; set; }
    public DbSet<ECData> ECData { get; set; }
    public DbSet<Pump> Pumps { get; set; }
    public DbSet<Measurement> Measurements { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure primary keys, relationships, etc.
        modelBuilder.Entity<Sensor>()
            .HasDiscriminator<string>("SensorType")
            .HasValue<TempSensor>("Temp")
           .HasValue<PhSensor>("Ph")
           .HasValue<ECSensor>("EC");

        modelBuilder.Entity<TempSensor>()
        .HasOne(ts => ts.TempData)
            .WithOne()
            .HasForeignKey<TempData>(td => td.Id);

    modelBuilder.Entity<TempSensor>()
        .HasOne(ts => ts.TempData)
            .WithOne()
            .HasForeignKey<TempData>(td => td.Id);

        modelBuilder.Entity<ECSensor>()
             .HasMany(e => e.ECData)
             .WithOne(ec => ec.ECSensor)
             .HasForeignKey(ec => ec.EcSensorId);
    }

public DbSet<SensorsProject.Models.Pump> Pump { get; set; } = default!;

public DbSet<SensorsProject.Models.User> User { get; set; } = default!;
}
