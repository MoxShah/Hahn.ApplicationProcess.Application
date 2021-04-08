namespace Hahn.ApplicationProcess.February2021.Data.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Asset
    {
        [Key]
        public int ID { get; set; }
        public string AssetName { get; set; }
        public byte Department { get; set; }
        public string CountryOfDepartment { get; set; }
        public string EMailAddressOfDepartment { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool Broken { get; set; } = false;
    }
}
