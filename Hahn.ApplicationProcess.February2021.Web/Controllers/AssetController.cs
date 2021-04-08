namespace Hahn.ApplicationProcess.February2021.Web.Controllers
{
    using System.Collections.Generic;
    using Hahn.ApplicationProcess.February2021.Domain.BusinessModels;
    using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Asset Controller
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        /// <summary>
        /// The asset business information
        /// </summary>
        IAssetBusinessInformation assetBusinessInformation;
        /// <summary>
        /// Initializes a new instance of the <see cref="AssetController"/> class.
        /// </summary>
        /// <param name="assetBusinessInformation">The asset business information.</param>
        public AssetController(IAssetBusinessInformation assetBusinessInformation)
        {
            this.assetBusinessInformation = assetBusinessInformation;
        }

        /// <summary>
        /// Creates the asset.
        /// </summary>
        /// <param name="assetModel">The asset model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateAsset(AssetModel assetModel)
        {
            return base.Created("System.URI", assetBusinessInformation.CreateAsset(assetModel));
        }
        /// <summary>
        /// Updates the asset.
        /// </summary>
        /// <param name="assetModel">The asset model.</param>
        /// <returns></returns>
        [HttpPut]
        public AssetModel UpdateAsset(AssetModel assetModel)
        {
            return assetBusinessInformation.UpdateAsset(assetModel);
        }

        /// <summary>
        /// Gets the asset.
        /// </summary>
        /// <param name="Id" example="1">The asset identifier.</param>
        /// <example>1</example>
        [HttpGet]
        [Route("{Id}")]
        public AssetModel GetAsset(int Id)
        {

            return assetBusinessInformation.GetAsset(Id);
        }

        /// <summary>
        /// Gets all asset.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<AssetModel> GetAllAsset()
        {
            return assetBusinessInformation.GetAllAsset();
        }

        /// <summary>
        /// Deletes the asset.
        /// </summary>
        /// <param name="Id" example="1">The asset identifier.</param>
        [HttpDelete]
        [Route("{Id}")]
        public void DeleteAsset(int Id)
        {
            assetBusinessInformation.DeleteAsset(Id);
        }
    }
}
