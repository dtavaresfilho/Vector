using System;

namespace Vector.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Mail { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
