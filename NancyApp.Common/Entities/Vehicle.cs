using System;

namespace NancyApp.Common.Entities
{
    public class Vehicle : BaseEntity<Guid>
    {
        public string Color { get; set; }
        public string Name { get; set; }
        public int Horsepowers { get; set; }
    }
}
