using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ArchitectureLearning.CQRS.Persistence.DbContext;
using ArchitectureLearning.CQRS.Persistence.Entities;
using ArchitectureLearning.CQRS.Queries.todos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArchitectureLearning.CQRS.Handlers.todos
{
    public class GetTodoHandler : IRequestHandler<GetTodoByIdQueries, Todo>
    {
        private ArchitectureCqrsContext _context;
        public GetTodoHandler(ArchitectureCqrsContext context)
        {
            _context = context;
        }
        public async Task<Todo> Handle(GetTodoByIdQueries request, CancellationToken cancellationToken)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(c => c.Id == request.TodoId, cancellationToken: cancellationToken);
            return todo;
        }
    }
}