using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SongApplication.Models
{
    public class Artists
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("releases")]
        public Release[] Releases { get; set; }
    }

}
