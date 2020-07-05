using System.Collections.Generic;
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
    public class GetAllOrdersHandler : IRequestHandler<GetAllTodosQueries, List<Todo>>
    {
        private ArchitectureCqrsContext _context;
        public GetAllOrdersHandler(ArchitectureCqrsContext context)
        {
            _context = context;
        }
        
        public async Task<List<Todo>> Handle(GetAllTodosQueries request, CancellationToken cancellationToken)
        {
            return await _context.Todos.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}