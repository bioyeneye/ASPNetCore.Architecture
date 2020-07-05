using ArchitectureLearning.CQRS.Persistence.Entities;
using MediatR;

namespace ArchitectureLearning.CQRS.Commands
{
    public class CreateTodoCommand : IRequest<Todo>
    {
        public CreateTodoCommand(string task, bool isCompleted)
        {
            Task = task;
            IsCompleted = isCompleted;
        }

        public string Task { get; }
        public bool IsCompleted { get;}
    }
}