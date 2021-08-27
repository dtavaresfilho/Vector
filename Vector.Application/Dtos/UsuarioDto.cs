using System;

namespace Vector.Application.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Mail { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
