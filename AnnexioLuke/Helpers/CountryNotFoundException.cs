using System;

namespace AnnexioLuke.Helpers
{
  
    public class CountryNotFoundException : Exception
    {

        public CountryNotFoundException(string field, String value)
        : base(String.Format("Country not found using field '{0}' with value '{1}.", field, value))
        {
        }
    }
}