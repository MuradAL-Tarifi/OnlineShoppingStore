using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore
{
    public class PaypalConfiguration
    {
        public readonly static string clientId;
        public readonly static string clientSecret;

        static PaypalConfiguration()
        {
            var config = getconfig();
            clientId = "Ae7Y-oLuKXEOKGKZZd-4_JIUWRV2sqYxLPJXFrHYMlaz9mxvxSjH038T39icxXtIV90ylZwQ3F79YH5v";
            clientSecret = "EGU3QZIDU2C5Hxu66fGKx0G4o7rFBo27-Xi71IzvbgFoKyeS_oyAc6WUhlZAE6A6Uyn8kX0kuDj3w-oo";
        }

        private static Dictionary<string , string> getconfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }
        private static string GetAccessToken()
        {
            string accrssToken = new OAuthTokenCredential(clientId, clientSecret, getconfig()).GetAccessToken();
            return accrssToken;
        }
        private static APIContext GetAPIContext()
        {
            APIContext apicontext = new APIContext(GetAccessToken());
            apicontext.Config = getconfig();
            return apicontext;
        }
    }
}