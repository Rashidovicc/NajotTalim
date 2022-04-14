using Microsoft.AspNetCore.Http;
using System;
using System.Text;

namespace NajotTalim.Services.Helpers
{
    public class HttpContextHelper
    {
        public static IHttpContextAccessor Accessor;
        public static HttpContext Context => Accessor?.HttpContext;
        public static IHeaderDictionary ResponseHeaders => Context?.Response?.Headers;



        private static string BasicAuth => Context?.Request?.Headers["Authorization"].ToString();
        public static string BasicUsername => GetBasicCredientals().username;
        public static string BasicPassword => GetBasicCredientals().password;

        private static (string username, string password) GetBasicCredientals()
        {
            string [] basicToken = BasicAuth.Split(' ');

            if(basicToken.Length != 2)
                return (string.Empty, string.Empty);

            byte[] data = Convert.FromBase64String(basicToken[1]);
            string decodedString = Encoding.UTF8.GetString(data);

            return (decodedString.Split(':')[0],decodedString.Split(':')[1]);
        }
    }
}
