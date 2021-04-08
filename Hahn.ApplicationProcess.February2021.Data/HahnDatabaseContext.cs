namespace Hahn.ApplicationProcess.February2021.Data
{
    using Hahn.ApplicationProcess.February2021.Data.DatabaseModels;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Hahn Database context
    /// </summary>
    /// <seealso cref="DbContext" />
    public class HahnDatabaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HahnDatabaseContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public HahnDatabaseContext(DbContextOptions<HahnDatabaseContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the assets.
        /// </summary>
        /// <value>
        /// The assets.
        /// </value>
        public DbSet<Asset> Assets { get; set; }
    }
}
