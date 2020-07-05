using System.Threading;
using System.Threading.Tasks;
using ArchitectureLearning.CQRS.Commands;
using ArchitectureLearning.CQRS.Persistence.DbContext;
using ArchitectureLearning.CQRS.Persistence.Entities;
using MediatR;

namespace ArchitectureLearning.CQRS.Handlers.todos
{
    public class CreateTodoHandler : IRequestHandler<CreateTodoCommand, Todo>
    {
        private ArchitectureCqrsContext _context;

        public CreateTodoHandler(ArchitectureCqrsContext context)
        {
            _context = context;
        }

        public async Task<Todo> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = await _context.Todos.AddAsync(new Todo()
            {
                Task = request.Task,
                IsCompleted = request.IsCompleted
            }, cancellationToken);


            var response = await _context.SaveChangesAsync(cancellationToken);

            return todo.Entity;
        }
    }
}