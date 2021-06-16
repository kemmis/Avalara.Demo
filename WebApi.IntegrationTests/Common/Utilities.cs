using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Models;
using Newtonsoft.Json;

namespace WebApi.IntegrationTests.Common
{
    public class Utilities
    {
        public static StringContent GetRequestContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        public static async Task<ServiceResult<T>> GetResponseContent<T>(HttpResponseMessage response)
        {
            var stringResponse = await
                response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResult<T>>(stringResponse);

            return result;
        }
    }
}
