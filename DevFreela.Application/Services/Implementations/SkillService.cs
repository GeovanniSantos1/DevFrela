using Dapper;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;

namespace DevFreela.Application.Services.Implementations;

public class SkillService : ISkillService
{
    private readonly DevFreelaDbContext _dbContext;

    public SkillService(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public List<SkillViewModel> GetAll()
    {
        // var skills = _dbContext.Skills;
        //
        // var skillsViewModel = skills
        //     .Select(s => new SkillViewModel(s.Id, s.Description))
        //     .ToList();
        //
        // return skillsViewModel;
        
        using var sqlConnection = new SqlConnection(_dbContext.GetConnectionString());
        sqlConnection.Open();

        const string script = "SELECT Id, Description FROM Skills";

        return sqlConnection.Query<SkillViewModel>(script).ToList();
        
    }
}