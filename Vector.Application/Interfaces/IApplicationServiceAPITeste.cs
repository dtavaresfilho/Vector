using System.Collections.Generic;
using Vector.Application.Dtos;

namespace Vector.Application.Interfaces
{
    public interface IApplicationServiceAPITeste
    {
        IEnumerable<UsuarioDto> GetUsuarios();
    }
}
