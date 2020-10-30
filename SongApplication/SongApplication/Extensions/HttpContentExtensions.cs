using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SongApplication.Extensions
{
    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent content)
        {
            var contentStream = await content.ReadAsStreamAsync();

            using var streamReader = new StreamReader(contentStream);
            using var jsonReader = new JsonTextReader(streamReader);

            var serializer = new Newtonsoft.Json.JsonSerializer();

            try
            {
                return serializer.Deserialize<T>(jsonReader);
            }
            catch (JsonReaderException ex)
            {
                throw ex;
            }
        }
    }
}
