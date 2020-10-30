using Newtonsoft.Json;
using SongApplication.Enums;
using System;

namespace SongApplication.Models
{
    public class Release
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("release-group")]
        public ReleaseGroup ReleaseGroup { get; set; }

        [JsonProperty("track-count")]
        public long TrackCount { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public Status? Status { get; set; }

        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        public string Date { get; set; }
    }

}
