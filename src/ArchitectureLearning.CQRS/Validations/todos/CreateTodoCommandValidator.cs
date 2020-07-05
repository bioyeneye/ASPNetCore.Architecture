using ArchitectureLearning.CQRS.Commands;
using FluentValidation;

namespace ArchitectureLearning.CQRS.Validations.todos
{
    public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
    {
        public CreateTodoCommandValidator()
        {
            RuleFor(x => x.Task)
                .NotEmpty();
        }
    }
}