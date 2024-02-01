using AutoMapper.Configuration;
using Microsoft.Extensions.Configuration;

namespace env
{
    public static class IConfigurationService
    {
        private static IConfiguration _oConfiguration = null;

        public static void SetConfig(IConfiguration oIConfiguration)
        {
            if (_oConfiguration == null)
            {
                _oConfiguration = oIConfiguration;
            }
        }


        public static string getConectionString()
        {
            return _oConfiguration.GetConnectionString(string.Format("CHAD_{0}", _oConfiguration["Ambiente"]));
        }
    }
}
