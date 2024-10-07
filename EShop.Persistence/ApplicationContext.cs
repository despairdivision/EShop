using EShop.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EShop.Persistence;
public class ApplicationContext(DbContextOptions<ApplicationContext> options,
                                IConfiguration config) : DbContext(options)
{
    public DbSet<UserEntity> Users {get; set;}

    public DbSet<PhoneNumberEntity> PhoneNumbers { get; set; }

    public DbSet<EmailAdressEntity> EmailAdresses { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(config.GetConnectionString("PostgresqlConnectionString"));
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PhoneNumberEntity>(builder =>
        {
            builder.ComplexProperty(p => p.Number, b => 
            {
                b.IsRequired();
                b.Property(p => p.Number).HasColumnName("PhoneNumber");
            });
        });

        modelBuilder.Entity<EmailAdressEntity>(builder =>
        {
            builder.ComplexProperty(p => p.Adress, b =>
            {
                b.IsRequired();
                b.Property(p => p.Adress).HasColumnName("EmailAdress");
            });
        });

        base.OnModelCreating(modelBuilder);
    }
}
