using ArchitectureLearning.CQRS.Persistence.Entities;
using MediatR;

namespace ArchitectureLearning.CQRS.Queries.todos
{
    public class GetTodoByIdQueries : IRequest<Todo>
    {
        public GetTodoByIdQueries(int todoId)
        {
            TodoId = todoId;
        }

        public int TodoId { get; }
    }
}