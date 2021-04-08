namespace Hahn.ApplicationProcess.February2021.Domain.BusinessImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Hahn.ApplicationProcess.February2021.Data.DatabaseModels;
    using Hahn.ApplicationProcess.February2021.Data.Interfaces;
    using Hahn.ApplicationProcess.February2021.Domain.BusinessModels;
    using Hahn.ApplicationProcess.February2021.Domain.Interfaces;

    /// <summary>
    /// Asset business implementation
    /// </summary>
    /// <seealso cref="IAssetBusinessInformation" />
    public class AssetBusinessImplementation : IAssetBusinessInformation
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetBusinessImplementation" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public AssetBusinessImplementation(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public List<AssetModel> GetAllAsset()
        {
            return ConvertDataToModel(unitOfWork.assetInformation.GetAll().Result.ToList());
        }

        /// <summary>
        /// Deletes the asset.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <exception cref="InvalidOperationException"></exception>
        public void DeleteAsset(int Id)
        {
            var assetData = unitOfWork.assetInformation.Get(Id).Result;
            if (assetData == null)
            {
                throw new InvalidOperationException();
            }
            unitOfWork.assetInformation.Delete(assetData);
            unitOfWork.Complete();
        }

        /// <summary>
        /// Gets the asset.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public AssetModel GetAsset(int Id)
        {
            var assetData = unitOfWork.assetInformation.Get(Id).Result;
            return new AssetModel()
            {
                AssetName = assetData.AssetName,
                Broken = assetData.Broken,
                CountryOfDepartment = assetData.CountryOfDepartment,
                Department = (Department)Enum.Parse(typeof(Department),Convert.ToString(assetData.Department)),
                EMailAddressOfDepartment = assetData.EMailAddressOfDepartment,
                ID = assetData.ID,
                PurchaseDate = assetData.PurchaseDate
            };

        }

        /// <summary>
        /// Creates the asset.
        /// </summary>
        /// <param name="assetModel">The asset model.</param>
        /// <returns></returns>
        public AssetModel CreateAsset(AssetModel assetModel)
        {
            var assetData = ConvertModelToData(assetModel);
            unitOfWork.assetInformation.Add(assetData);
            unitOfWork.Complete();
            assetModel.ID = assetData.ID;
            return assetModel;
        }

        /// <summary>
        /// Updates the asset.
        /// </summary>
        /// <param name="assetModel">The asset model.</param>
        /// <returns></returns>
        public AssetModel UpdateAsset(AssetModel assetModel)
        {
            var assetData = ConvertModelToData(assetModel);
            unitOfWork.assetInformation.Update(assetData);
            unitOfWork.Complete();
            return assetModel;
        }

        /// <summary>
        /// Converts the data to model.
        /// </summary>
        /// <param name="assetData">The asset data.</param>
        /// <returns></returns>
        private AssetModel ConvertDataToModel(Asset assetData)
        {
            return new AssetModel()
            {
                AssetName = assetData.AssetName,
                Broken = assetData.Broken,
                CountryOfDepartment = assetData.CountryOfDepartment,
                Department = (Department)Enum.Parse(typeof(Department), Convert.ToString(assetData.Department)),
                EMailAddressOfDepartment = assetData.EMailAddressOfDepartment,
                ID = assetData.ID,
                PurchaseDate = assetData.PurchaseDate
            };
        }

        /// <summary>
        /// Converts the data to model.
        /// </summary>
        /// <param name="assetData">The asset data.</param>
        /// <returns></returns>
        private List<AssetModel> ConvertDataToModel(List<Asset> assetData)
        {
            List<AssetModel> assets = new List<AssetModel>();
            assetData.ForEach(asset =>
            {
                assets.Add(new AssetModel()
                {
                    AssetName = asset.AssetName,
                    Broken = asset.Broken,
                    CountryOfDepartment = asset.CountryOfDepartment,
                    Department = (Department)Enum.Parse(typeof(Department), Convert.ToString(asset.Department)),
                    EMailAddressOfDepartment = asset.EMailAddressOfDepartment,
                    ID = asset.ID,
                    PurchaseDate = asset.PurchaseDate
                });
            });
            return assets;
        }


        /// <summary>
        /// Converts the model to data.
        /// </summary>
        /// <param name="assetModel">The asset model.</param>
        /// <returns></returns>
        private Asset ConvertModelToData(AssetModel assetModel)
        {
            return new Asset()
            {
                AssetName = assetModel.AssetName,
                Broken = assetModel.Broken,
                CountryOfDepartment = assetModel.CountryOfDepartment,
                Department = (byte)assetModel.Department,
                EMailAddressOfDepartment = assetModel.EMailAddressOfDepartment,
                ID = assetModel.ID,
                PurchaseDate = assetModel.PurchaseDate
            };
        }
    }
}
