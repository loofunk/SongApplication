using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongApplication.Models
{
    public class Song
    {
        [JsonProperty("lyrics")]
        public string Lyrics { get; set; }
    }
}
