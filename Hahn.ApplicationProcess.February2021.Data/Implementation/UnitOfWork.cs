namespace Hahn.ApplicationProcess.February2021.Data.Implementation
{
    using Hahn.ApplicationProcess.February2021.Data.Interfaces;
    using System;

    /// <summary>
    /// Unit of work implementation
    /// </summary>
    /// <seealso cref="IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The d b context
        /// </summary>
        private readonly HahnDatabaseContext dBContext;

        /// <summary>
        /// Gets the asset information.
        /// </summary>
        /// <value>
        /// The asset information.
        /// </value>
        public IAssetInformation assetInformation { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        /// <param name="dBContext">The d b context.</param>
        /// <param name="assetInformation">The asset information.</param>
        public UnitOfWork(HahnDatabaseContext dBContext, IAssetInformation assetInformation)
        {
            this.dBContext = dBContext;
            this.assetInformation = assetInformation;
        }

        /// <summary>
        /// Completes this instance.
        /// </summary>
        /// <returns></returns>
        public int Complete()
        {
            return dBContext.SaveChanges();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                dBContext.Dispose();
            }
        }
    }
}
