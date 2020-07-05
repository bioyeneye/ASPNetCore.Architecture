using System;
using System.Collections.Generic;

namespace ArchitectureLearning.CQRS.Persistence.Entities
{
    public partial class Todo
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public bool IsCompleted { get; set; }
    }
}
