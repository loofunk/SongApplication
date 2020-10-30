using Newtonsoft.Json;
using System;

namespace SongApplication.Models
{
    public class Artist
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sort-name")]
        public string SortName { get; set; }
    }

}
