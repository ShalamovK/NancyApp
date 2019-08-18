using System;

namespace NancyApp.Common.Entities
{
    public interface IEntity<T>
        where T : IEquatable<T>
    {
        T Id { get; set; }
    }
}
