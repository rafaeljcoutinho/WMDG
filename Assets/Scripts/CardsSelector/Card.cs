using Newtonsoft.Json;
public class Card {
    [JsonProperty("id")]
    private string id {get; set; }
    [JsonProperty("name")]
    public string name {get; set;}
    [JsonProperty("description")]
    public string description {get; set;}
    [JsonProperty("type")]
    public string type {get; set;}
    [JsonProperty("image")]
    public string image {get; set;}
    [JsonProperty("modifier")]
    public string modifier {get; set;}

    public Card(string id, string name, string description, string type, string image){
        this.id = id;
        this.name = name;
        this.description = description;
        this.type = type;
        this.image = image;
    }

}