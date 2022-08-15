using AppREstCountries.Helpers;
using Newtonsoft.Json.Linq;
using RESTCountries.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using static RESTCountries.Constants.APIResources;

namespace AnnexioLuke.Services
{
 
    public static class RESTCountriesAPI
    {
     
        public static readonly RestClient client = new RestClient();


        public static async Task<List<Country>> GetAllCountriesAsync()
        {
            var request = new RestRequest(
                $"{RESTCOUNTRIES_BASE_URI}{ALL_COUNTRY_SIFFIX_URI}",
                Method.GET,
                DataFormat.Json);
            IRestResponse response = await client.ExecuteGetAsync(request);
            if (response.IsSuccessful && response.StatusCode.HasFlag(HttpStatusCode.OK))
            {
                JArray jsonArray = JArray.Parse(response.Content);
                return jsonArray.ToObject<List<Country>>();
            }
            throw new Exception("No country found. Please check if https://restcountries.com is available.");
        }


        public static async Task<List<Country>> GetCountriesByNameContainsAsync(string name)
        {
            var request = new RestRequest(
                $"{RESTCOUNTRIES_BASE_URI}{COUNTRY_BY_NAME_SIFFIX_URI}{name}",
                Method.GET,
                DataFormat.Json);
            IRestResponse response = await client.ExecuteGetAsync(request);
            if (response.IsSuccessful && response.StatusCode.HasFlag(HttpStatusCode.OK))
            {
                JArray jsonArray = JArray.Parse(response.Content);
                return jsonArray.ToObject<List<Country>>();
            }
            throw new CountryNotFoundException("name", name);
        }


        public static async Task<Country> GetCountryByFullNameAsync(string fullName)
        {
            var request = new RestRequest(
                $"{RESTCOUNTRIES_BASE_URI}{COUNTRY_BY_NAME_SIFFIX_URI}{fullName}{COUNTRY_BY_FULLNAME_SUFFIX_URI}",
                Method.GET,
                DataFormat.Json);
            IRestResponse response = await client.ExecuteGetAsync(request);
            if (response.IsSuccessful && response.StatusCode.HasFlag(HttpStatusCode.OK))
            {
                JArray jsonArray = JArray.Parse(response.Content);
                return jsonArray[0].ToObject<Country>();
            }
            throw new CountryNotFoundException("fullName", fullName);
        }


        public static async Task<Country> GetCountryByCodeAsync(string countryCode)
        {
            var request = new RestRequest(
                $"{RESTCOUNTRIES_BASE_URI}{COUNTRY_BY_CODE_SIFFIX_URI}{countryCode}",
                Method.GET,
                DataFormat.Json);
            IRestResponse response = await client.ExecuteGetAsync(request);
            if (response.IsSuccessful && response.StatusCode.HasFlag(HttpStatusCode.OK))
            {
                JObject jsonObject = JObject.Parse(response.Content);
                return jsonObject.ToObject<Country>();
            }
            throw new CountryNotFoundException("countryCode", countryCode);
        }


        public static async Task<List<Country>> GetCountriesByCodesAsync(params string[] codes)
        {
            if (codes.Length == 0)
                throw new Exception("Parameter(s) can't not be null for argument 'codes'");

            string queryParams = string.Join(",", codes);
            var request = new RestRequest(
                $"{RESTCOUNTRIES_BASE_URI}{COUNTRY_BY_LISTOFCODES_SIFFIX_URI}{queryParams}",
                Method.GET,
                DataFormat.Json);
            IRestResponse response = await client.ExecuteGetAsync(request);
            if (response.IsSuccessful && response.StatusCode.HasFlag(HttpStatusCode.OK))
            {
                JArray jsonArray = JArray.Parse(response.Content);
                return jsonArray.ToObject<List<Country>>();
            }
            throw new CountryNotFoundException("codes", queryParams);
        }


        public static async Task<List<Country>> GetCountriesByCurrencyCodeAsync(string currencyCode)
        {
            var request = new RestRequest(
                $"{RESTCOUNTRIES_BASE_URI}{COUNTRY_BY_CURRENCYCODE}{currencyCode}",
                Method.GET,
                DataFormat.Json);
            IRestResponse response = await client.ExecuteGetAsync(request);
            if (response.IsSuccessful && response.StatusCode.HasFlag(HttpStatusCode.OK))
            {
                JArray jsonArray = JArray.Parse(response.Content);
                return jsonArray.ToObject<List<Country>>();
            }
            throw new CountryNotFoundException("currencycode", currencyCode);
        }


        public static async Task<List<Country>> GetCountriesByLanguageCodeAsync(string languageCode)
        {
            var request = new RestRequest(
                $"{RESTCOUNTRIES_BASE_URI}{COUNTRY_BY_LANGUAGECODE}{languageCode}",
                Method.GET,
                DataFormat.Json);
            IRestResponse response = await client.ExecuteGetAsync(request);
            if (response.IsSuccessful && response.StatusCode.HasFlag(HttpStatusCode.OK))
            {
                JArray jsonArray = JArray.Parse(response.Content);
                return jsonArray.ToObject<List<Country>>();
            }
            throw new CountryNotFoundException("languageCode", languageCode);
        }


        public static async Task<Country> GetCountryByCapitalCityAsync(string capitalCity)
        {
            var request = new RestRequest(
                $"{RESTCOUNTRIES_BASE_URI}{COUNTRY_BY_CAPITALCITY}{capitalCity}",
                Method.GET,
                DataFormat.Json);
            IRestResponse response = await client.ExecuteGetAsync(request);
            if (response.IsSuccessful && response.StatusCode.HasFlag(HttpStatusCode.OK))
            {
                JArray jsonArray = JArray.Parse(response.Content);
                return jsonArray[0].ToObject<Country>();
            }
            throw new CountryNotFoundException("capitalCity", capitalCity);
        }


        public static async Task<List<Country>> GetCountriesByCallingCodeAsync(string callingCode)
        {
            var request = new RestRequest(
                $"{RESTCOUNTRIES_BASE_URI}{COUNTRY_BY_CALLINGCODE}{callingCode}",
                Method.GET,
                DataFormat.Json);
            IRestResponse response = await client.ExecuteGetAsync(request);
            if (response.IsSuccessful && response.StatusCode.HasFlag(HttpStatusCode.OK))
            {
                JArray jsonArray = JArray.Parse(response.Content);
                return jsonArray.ToObject<List<Country>>();
            }
            throw new CountryNotFoundException("callingCode", callingCode);
        }

        public static async Task<List<Country>> GetCountriesByContinentAsync(string continent)
        {
            var allCountries = await GetAllCountriesAsync();
            return allCountries.Where(c => string.Equals(c.Region, continent, StringComparison.OrdinalIgnoreCase)).ToList();
        }


        public static async Task<List<Country>> GetCountriesByRegionalBlocAsync(string regionalBloc)
        {
            var request = new RestRequest(
                $"{RESTCOUNTRIES_BASE_URI}{COUNTRY_BY_REGIONALBLOC}{regionalBloc}",
                Method.GET,
                DataFormat.Json);
            IRestResponse response = await client.ExecuteGetAsync(request);
            if (response.IsSuccessful && response.StatusCode.HasFlag(HttpStatusCode.OK))
            {
                JArray jsonArray = JArray.Parse(response.Content);
                return jsonArray.ToObject<List<Country>>();
            }
            throw new CountryNotFoundException("regionalBloc", regionalBloc);
        }
    }
}