using Newtonsoft.Json;

namespace CarTrack_OMdbWebAPI.Model
{
    public class Rating
    {
        [JsonProperty("Source")]
        public string Source { get; set; }
        
        [JsonProperty("Value")]
        public string Value { get; set; }
    }
}
