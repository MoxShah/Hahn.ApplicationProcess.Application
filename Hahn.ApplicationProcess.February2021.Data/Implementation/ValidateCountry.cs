namespace Hahn.ApplicationProcess.February2021.Data.Implementation
{
    using System.Net.Http;
    using Hahn.ApplicationProcess.February2021.Data.Interfaces;

    /// <summary>
    /// Validate country
    /// </summary>
    /// <seealso cref="ICountryValidator" />
    public class ValidateCountry : ICountryValidator
    {
        /// <summary>
        /// The HTTP client
        /// </summary>
        HttpClient httpClient;
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateCountry"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        public ValidateCountry(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Validates the country.
        /// </summary>
        /// <param name="countryName">Name of the country.</param>
        /// <returns></returns>
        public bool ValidateCountryByName(string countryName)
        {
            var countryData = httpClient.GetAsync($"https://restcountries.eu/rest/v2/name/{countryName}?fullText=true").Result;
            return countryData.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
