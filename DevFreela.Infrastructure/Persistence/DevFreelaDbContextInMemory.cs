using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence;

public class DevFreelaDbContextInMemory
{
    public DevFreelaDbContextInMemory()
    {
        Projects = new List<Project>()
        {
            new Project("Meu projeto 1", "Descricao do meu projeto 1", 1, 2, 10000),
            new Project("Meu projeto 2", "Descricao do meu projeto 2", 1, 2, 20000),
            new Project("Meu projeto 3", "Descricao do meu projeto 3", 1, 2, 30000),
        };

        Users = new List<User>()
        {
            new User("Usuario 1", "email1@teste.com", new DateTime(1992, 1, 1),"123","user"),
            new User("Usuario 2", "email2@teste.com", new DateTime(1992, 1, 1),"123","user"),
            new User("Usuario 3", "email3@teste.com", new DateTime(1992, 1, 1),"123","user"),
        };

        Skills = new List<Skill>()
        {
            new Skill(".NET"),
            new Skill("Angular"),
            new Skill("React"),
        };
    }

    public List<Project> Projects { get; set; }
    public List<User> Users { get; set; }
    public List<Skill> Skills { get; set; }
    public List<ProjectComment> ProjectComments { get; set; }
}