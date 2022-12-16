using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Portfolio2.Models;

public class Portfolio
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string? SiteUrl { get; set; }

    public string GitUrl { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string ProjectType { get; set; }

    public string ImagePath { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string PersonId { get; set; }
}
