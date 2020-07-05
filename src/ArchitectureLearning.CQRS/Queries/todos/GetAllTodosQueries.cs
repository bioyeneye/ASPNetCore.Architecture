using System.Collections.Generic;
using ArchitectureLearning.CQRS.Persistence.Entities;
using MediatR;

namespace ArchitectureLearning.CQRS.Queries.todos
{
    public class GetAllTodosQueries : IRequest<List<Todo>>
    {
        
    }
}