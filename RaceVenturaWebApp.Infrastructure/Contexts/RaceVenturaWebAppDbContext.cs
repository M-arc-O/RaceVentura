using RaceVenturaWebApp.Infrastructure.Configurations;
using RaceVenturaWebApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace RaceVenturaWebApp.Infrastructure.Contexts;
public class RaceVenturaWebAppDbContext : DbContext
{
	public DbSet<Race>? BankAccounts { get; set; }

	public RaceVenturaWebAppDbContext(DbContextOptions<RaceVenturaWebAppDbContext> options) : base(options)
    {
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new RaceConfiguration());
	}

    public static void ConfigureDbContextOptions(DbContextOptionsBuilder optionsBuilder, string connectionString)
    {
		optionsBuilder
			.UseSqlServer(connectionString,
				sqlServerOptionsAction => sqlServerOptionsAction
					.CommandTimeout(100)
					.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
					.EnableRetryOnFailure(
						maxRetryCount: 10,
						maxRetryDelay: TimeSpan.FromSeconds(2),
						errorNumbersToAdd: null));
    }
}
