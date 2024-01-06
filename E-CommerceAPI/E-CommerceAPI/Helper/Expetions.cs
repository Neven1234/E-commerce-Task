﻿using Microsoft.AspNetCore.Http;
namespace E_CommerceAPI.Helper
{
    public static  class Expetions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Conrol-Allow-Origin", "*");
        }
    }
}
