using System;

namespace NancyApp.Common.Entities
{
    public class BaseEntity<T> : IEntity<T> where T : IEquatable<T>
    {
        public T Id { get; set; }
    }
}
