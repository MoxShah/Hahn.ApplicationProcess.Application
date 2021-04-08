namespace Hahn.ApplicationProcess.February2021.Data.Interfaces
{
    using System;

    /// <summary>
    /// Unit of work interface
    /// </summary>
    /// <seealso cref="IDisposable" />
    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// Gets the asset information.
        /// </summary>
        /// <value>
        /// The asset information.
        /// </value>
        IAssetInformation assetInformation { get; }

        /// <summary>
        /// Completes this instance.
        /// </summary>
        /// <returns></returns>
        int Complete();
    }
}
