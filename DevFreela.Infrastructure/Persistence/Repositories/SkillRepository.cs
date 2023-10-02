using Dapper;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly DevFreelaDbContext _dbContext;
    private readonly string _connectionString;
    public SkillRepository(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
        _connectionString = _dbContext.GetConnectionString();
    }
    
    public async Task<List<Skill>> GetAllAsync()
    {
        //Com DAPPER
        // await using var sqlConnection = new SqlConnection(_connectionString);
        // sqlConnection.Open();
        //
        // const string script = "SELECT Id, Description FROM Skills";
        //
        // var skills = await sqlConnection.QueryAsync<SkillDTO>(script);
        //
        // return skills.ToList();

        // COM EF CORE
        return await _dbContext.Skills.ToListAsync();
    }

    public async  Task AddSkillFromProject(Project project)
    {
        // App Xamarin de Marketplace
        var words = project.Description.Split(' ');
        var length = words.Length;

        var skill = $"{project.Id} - {words[length - 1]}";
        // "1 - Marketplace"
            
        await _dbContext.Skills.AddAsync(new Skill(skill));
    }
}