using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Mvc
{
    static class GlobaleVariable
    {
        public static HttpClient webApiClient = new HttpClient();

        static GlobaleVariable()
        {
            webApiClient.BaseAddress = new Uri ("https://localhost:44319/api/");
            webApiClient.DefaultRequestHeaders.Clear();
            webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}