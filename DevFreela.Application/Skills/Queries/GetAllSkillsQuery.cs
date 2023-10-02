using DevFreela.Application.ViewModels;
using DevFreela.Core.DTOs;
using MediatR;

namespace DevFreela.Application.Skills.Queries;

public class GetAllSkillsQuery : IRequest<List<SkillViewModel>>
{
}