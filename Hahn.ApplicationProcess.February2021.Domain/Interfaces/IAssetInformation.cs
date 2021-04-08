namespace Hahn.ApplicationProcess.February2021.Domain.Interfaces
{
    using System.Collections.Generic;
    using Hahn.ApplicationProcess.February2021.Domain.BusinessModels;


    /// <summary>
    /// Asset business interface
    /// </summary>
    public interface IAssetBusinessInformation
    {
        /// <summary>
        /// Creates the asset.
        /// </summary>
        /// <param name="assetModel">The asset model.</param>
        /// <returns></returns>
        public AssetModel CreateAsset(AssetModel assetModel);

        /// <summary>
        /// Updates the asset.
        /// </summary>
        /// <param name="assetModel">The asset model.</param>
        /// <returns></returns>
        public AssetModel UpdateAsset(AssetModel assetModel);

        /// <summary>
        /// Gets the asset.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public AssetModel GetAsset(int Id);
        /// <summary>
        /// Deletes the asset.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public void DeleteAsset(int Id);

        /// <summary>
        /// Gets all asset.
        /// </summary>
        public List<AssetModel> GetAllAsset();
    }
}
