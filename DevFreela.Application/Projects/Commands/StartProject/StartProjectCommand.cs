﻿using MediatR;

namespace DevFreela.Application.Projects.Commands.StartProject;

public class StartProjectCommand : IRequest<Unit>
{
    public StartProjectCommand(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}