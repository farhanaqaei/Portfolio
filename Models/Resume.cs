using MongoDB.Bson.Serialization.Attributes;

namespace Portfolio2.Models;

public class Resume
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }

    public ICollection<EducationOrExperience> EducationOrExperiences { get; set; }

    public ICollection<Skill> Skills { get; set; }

    public ICollection<string> Knoledge { get; set; }

}
