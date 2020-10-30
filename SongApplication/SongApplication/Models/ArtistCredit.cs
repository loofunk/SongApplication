using Newtonsoft.Json;

namespace SongApplication.Models
{
    public class ArtistCredit
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("artist")]
        public Artist Artist { get; set; }
    }

}
