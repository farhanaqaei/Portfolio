using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Portfolio2.Models;

public class Person
{
    #region properties

    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public string Residence { get; set; }

    public string Address { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string AboutMeDesc { get; set; }

    public string Profession { get; set; }

    public ICollection<SocialLinks> Socials { get; set; }

    public ICollection<WhatIDo> WhatIDos { get; set; }

    #endregion

    #region relations

    public string ResumeId { get; set; }

    public ICollection<Portfolio> Portfolios { get; set; }

    #endregion
}
