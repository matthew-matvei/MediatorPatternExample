using System;

namespace MediatorPatternExample.Models.Entities
{
    public class ValueEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
