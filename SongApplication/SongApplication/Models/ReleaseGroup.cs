using Newtonsoft.Json;
using System;

namespace SongApplication.Models
{
    public class ReleaseGroup
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("type-id")]
        public Guid TypeId { get; set; }

        [JsonProperty("primary-type-id")]
        public Guid PrimaryTypeId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

}
