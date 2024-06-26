﻿using MongoDB.Bson.Serialization.Attributes;

namespace Portfolio2.Models;

public class Resume
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }

    public ICollection<EducationOrWorkExperience> EducationOrWorkExperiences { get; set; }

    public ICollection<Skill> Skills { get; set; }

    public ICollection<string> SoftSkills { get; set; }

}
