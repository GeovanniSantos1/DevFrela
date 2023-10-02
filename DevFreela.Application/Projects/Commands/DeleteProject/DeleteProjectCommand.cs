using MediatR;

namespace DevFreela.Application.Projects.Commands.DeleteProject;

public class DeleteProjectCommand : IRequest<Unit>
{
    public DeleteProjectCommand(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}