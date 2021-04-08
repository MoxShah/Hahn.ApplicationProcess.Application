namespace Hahn.ApplicationProcess.February2021.Data.Interfaces
{
    /// <summary>
    /// Singature for Country validations
    /// </summary>
    public interface ICountryValidator
    {
        /// <summary>
        /// Validates the country.
        /// </summary>
        /// <param name="countryName">Name of the country.</param>
        /// <returns></returns>
        bool ValidateCountryByName(string countryName);
    }
}
