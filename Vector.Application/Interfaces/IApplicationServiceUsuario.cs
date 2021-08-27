using System.Collections.Generic;
using Vector.Application.Dtos;

namespace Vector.Application.Interfaces
{
    public interface IApplicationServiceUsuario
    {
        void Add(UsuarioDto usuarioDto);
        IEnumerable<UsuarioDto> GetAll();
    }
}
