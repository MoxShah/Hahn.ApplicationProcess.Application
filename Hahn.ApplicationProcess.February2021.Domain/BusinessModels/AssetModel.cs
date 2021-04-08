namespace Hahn.ApplicationProcess.February2021.Domain.BusinessModels
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class AssetModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        /// <example>1</example>

        public int ID { get; set; }
        /// <summary>
        /// Gets or sets the name of the asset.
        /// </summary>
        /// <value>
        /// The name of the asset.
        /// </value>
        /// <example>Some Asset</example>
        public string AssetName { get; set; }
        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>
        /// The department.
        /// </value>
        /// <example>1</example>
        public Department Department { get; set; }
        /// <summary>
        /// Gets or sets the country of department.
        /// </summary>
        /// <value>
        /// The country of department.
        /// </value>
        /// <example>India</example>
        public string CountryOfDepartment { get; set; }
        /// <summary>
        /// Gets or sets the e mail address of department.
        /// </summary>
        /// <value>
        /// The e mail address of department.
        /// </value>
        /// <example>mox.shah@yahoo.com</example>
        public string EMailAddressOfDepartment { get; set; }
        /// <summary>
        /// Gets or sets the purchase date.
        /// </summary>
        /// <value>
        /// The purchase date.
        /// </value>
        /// <example>2021-04-04</example>
        public DateTime PurchaseDate { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="AssetModel"/> is broken.
        /// </summary>
        /// <value>
        ///   <c>true</c> if broken; otherwise, <c>false</c>.
        /// </value>
        /// <example>false</example>
        public bool Broken { get; set; } = false;
    }
}
