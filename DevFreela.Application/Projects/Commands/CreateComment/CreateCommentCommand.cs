﻿using MediatR;

namespace DevFreela.Application.Projects.Commands.CreateComment;

public class CreateCommentCommand : IRequest<Unit>
{
    public string Content { get; set; }
    public int IdProject { get; set; }
    public int IdUser { get; set; }
}