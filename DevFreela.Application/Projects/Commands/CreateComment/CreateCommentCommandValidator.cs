using FluentValidation;

namespace DevFreela.Application.Projects.Commands.CreateComment;

public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(p => p.Content)
            .MaximumLength(255)
            .WithMessage("Tamanho máximo de Texto de Comentário é de 255 caracteres.");
    }
}