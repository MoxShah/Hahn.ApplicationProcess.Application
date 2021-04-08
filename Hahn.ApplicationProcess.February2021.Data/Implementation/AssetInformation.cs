namespace Hahn.ApplicationProcess.February2021.Data.Implementation
{
    using Hahn.ApplicationProcess.February2021.Data.DatabaseModels;
    using Hahn.ApplicationProcess.February2021.Data.Interfaces;

    /// <summary>
    /// Asset information
    /// </summary>
    /// <seealso cref="GenericRepository{Asset}" />
    /// <seealso cref="IAssetInformation" />
    public class AssetInformation : GenericRepository<Asset>, IAssetInformation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssetInformation"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public AssetInformation(HahnDatabaseContext dbContext):base(dbContext)
        {
        }
    }
}
