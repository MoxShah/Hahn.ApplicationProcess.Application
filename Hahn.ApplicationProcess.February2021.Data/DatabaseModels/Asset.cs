namespace Hahn.ApplicationProcess.February2021.Data.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Asset Model
    /// </summary>
    public class Asset
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Gets or sets the name of the asset.
        /// </summary>
        /// <value>
        /// The name of the asset.
        /// </value>
        public string AssetName { get; set; }
        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>
        /// The department.
        /// </value>
        public byte Department { get; set; }
        /// <summary>
        /// Gets or sets the country of department.
        /// </summary>
        /// <value>
        /// The country of department.
        /// </value>
        public string CountryOfDepartment { get; set; }
        /// <summary>
        /// Gets or sets the e mail address of department.
        /// </summary>
        /// <value>
        /// The e mail address of department.
        /// </value>
        public string EMailAddressOfDepartment { get; set; }
        /// <summary>
        /// Gets or sets the purchase date.
        /// </summary>
        /// <value>
        /// The purchase date.
        /// </value>
        public DateTime PurchaseDate { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Asset"/> is broken.
        /// </summary>
        /// <value>
        ///   <c>true</c> if broken; otherwise, <c>false</c>.
        /// </value>
        public bool Broken { get; set; } = false;
    }
}
