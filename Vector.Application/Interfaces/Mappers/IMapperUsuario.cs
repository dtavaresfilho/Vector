using System.Collections.Generic;
using Vector.Application.Dtos;
using Vector.Domain.Entities;

namespace Vector.Application.Interfaces.Mappers
{
    public interface IMapperUsuario
    {
        Usuario MapperDtoToEntity(UsuarioDto usuarioDto);
        UsuarioDto MapperEntityToDto(Usuario usuario);
        IEnumerable<UsuarioDto> MapperListUsuariosDto(IEnumerable<Usuario> usuarios);
    }
}
