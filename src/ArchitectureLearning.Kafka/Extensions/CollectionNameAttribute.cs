using System;

namespace ArchitectureLearning.Kafka.Extensions
{
    public class CollectionNameAttribute : Attribute
    {
        public string CollectionName { get; }

        public CollectionNameAttribute(string name)
        {
            CollectionName = name;
        }
    }
}