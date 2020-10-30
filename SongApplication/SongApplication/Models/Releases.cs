using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongApplication.Models
{

    public  class Releases
    {
        [JsonProperty("disambiguation")]
        public string Disambiguation { get; set; }

        [JsonProperty("packaging-id")]
        public object PackagingId { get; set; }

        [JsonProperty("text-representation")]
        public TextRepresentation TextRepresentation { get; set; }

        [JsonProperty("media")]
        public Media[] Media { get; set; }

        [JsonProperty("barcode")]
        public object Barcode { get; set; }

        //[JsonProperty("status-id")]
        //public Guid StatusId { get; set; }

        //[JsonProperty("id")]
        //public Guid Id { get; set; }

        [JsonProperty("packaging")]
        public object Packaging { get; set; }

        [JsonProperty("asin")]
        public object Asin { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("cover-art-archive")]
        public CoverArtArchive CoverArtArchive { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("quality")]
        public string Quality { get; set; }
    }

    public partial class CoverArtArchive
    {
        [JsonProperty("back")]
        public bool Back { get; set; }

        [JsonProperty("darkened")]
        public bool Darkened { get; set; }

        [JsonProperty("artwork")]
        public bool Artwork { get; set; }

        [JsonProperty("front")]
        public bool Front { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }
    }

    public partial class Media
    {
        [JsonProperty("tracks")]
        public Track[] Tracks { get; set; }

        [JsonProperty("position")]
        public long Position { get; set; }

        //[JsonProperty("format-id")]
        //public Guid FormatId { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("track-count")]
        public long TrackCount { get; set; }

        [JsonProperty("track-offset")]
        public long TrackOffset { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public partial class Track
    {
        [JsonProperty("position")]
        public long Position { get; set; }

        //[JsonProperty("number")]
        //[JsonConverter(typeof(ParseStringConverter))]
        //public long Number { get; set; }

        //[JsonProperty("id")]
        //public Guid Id { get; set; }

        [JsonProperty("recording")]
        public Recording Recording { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("length")]
        public object Length { get; set; }
    }

    public class Recording
    {
        [JsonProperty("length")]
        public object Length { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }

        [JsonProperty("disambiguation")]
        public string Disambiguation { get; set; }

        //[JsonProperty("id")]
        //public Guid Id { get; set; }
    }

    public partial class TextRepresentation
    {
        [JsonProperty("language")]
        public object Language { get; set; }

        [JsonProperty("script")]
        public object Script { get; set; }
    }
}
