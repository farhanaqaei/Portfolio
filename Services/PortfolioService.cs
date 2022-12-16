using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Portfolio2.Dtos;
using Portfolio2.Models;

namespace Portfolio2.Services;

public class PortfolioService
{
    private readonly IMongoCollection<Person> _personsCollection;
    private readonly IMongoCollection<Resume> _resumesCollection;
    private readonly IMongoCollection<Portfolio> _portfoliosCollection;
    private readonly string? envConnectionString = Environment.GetEnvironmentVariable("DATABASE_URL");

    public PortfolioService(
        IOptions<PortfolioDBSettings> portfolioDatabaseSettings)
    {
        // for development
        //var mongoClient = new MongoClient(portfolioDatabaseSettings.Value.ConnectionString);

        // for deployment
        var mongoClient = new MongoClient(envConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            portfolioDatabaseSettings.Value.DatabaseName);

        _personsCollection = mongoDatabase.GetCollection<Person>(
            portfolioDatabaseSettings.Value.PersonCollectionName);

        _resumesCollection = mongoDatabase.GetCollection<Resume>(
            portfolioDatabaseSettings.Value.ResumeCollectionName);

        _portfoliosCollection = mongoDatabase.GetCollection<Portfolio>(
            portfolioDatabaseSettings.Value.PortfolioCollectionName);
    }

    public Person GetPersonalData() => _personsCollection.Find(_ => true).FirstOrDefault();

    public ResumeDTO GetResume()
    {
        var resumeDto = new ResumeDTO();
        var person = GetPersonalData();
        var resume = _resumesCollection.Find(x => x.Id == person.ResumeId).FirstOrDefault();
        resumeDto.Resume = resume;
        resumeDto.Person= person;
        return resumeDto;
    }

    public List<Portfolio> GetPortfolios()
    {
        var portfolios = (from person in _personsCollection.AsQueryable()
                          join portfolio in _portfoliosCollection.AsQueryable()
                          on person.Id equals portfolio.PersonId
                          select portfolio).ToList();
                          
        return portfolios;
    }
}
