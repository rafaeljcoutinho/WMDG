public class Card {
    private string id {get;}
    private string name {get; set;}
    private string description {get; set;}
    private string type {get; set;}
    private string image {get; set;}

    public Card(string id, string name, string description, string type, string image){
        this.id = id;
        this.name = name;
        this.description = description;
        this.type = type;
        this.image = image;
    }

}