using System.Collections.Generic;
using Newtonsoft.Json;

public class Card
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("image")]
        public string image { get; set; }

        [JsonProperty("modifier")]
        public int modifier { get; set; }
    }

    public class Root
    {
        [JsonProperty("Cards")]
        public List<Card> Cards { get; set; }
    }