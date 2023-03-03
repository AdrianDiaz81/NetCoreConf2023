using Avengers.API.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace Avengers.API.Data;

public class AvengerDbContext :DbContext
{
    public DbSet<AvengerCharacter> Avengers { get; set; }

	public AvengerDbContext(DbContextOptions<AvengerDbContext> options): base(options)
	{
		this.Database.EnsureCreated();
		this.SaveChanges();
	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var dataCustomer = JObject.Parse(File.ReadAllText(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/Data/avengers.json"));
        var customerCollection = (JArray)dataCustomer["d"];
        IEnumerable<AvengerCharacter> avengersCollection = customerCollection.ToObject<IList<AvengerCharacter>>();
        modelBuilder.Entity<AvengerCharacter>().HasData(avengersCollection);
    }
}
