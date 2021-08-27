using System.Collections.Generic;
using System.Linq;
using Vector.Application.Dtos;
using Vector.Application.Interfaces.Mappers;
using Vector.Domain.Entities;

namespace Vector.Application.Mappers
{
    public class MapperUsuario : IMapperUsuario
    {
        public Usuario MapperDtoToEntity(UsuarioDto usuarioDto)
        {
            Usuario usuario = new Usuario
            {
                CreatedAt = usuarioDto.CreatedAt,
                Name = usuarioDto.Name,
                Avatar = usuarioDto.Avatar,
                Mail = usuarioDto.Mail,
                DataRegistro = usuarioDto.DataRegistro
            };

            return usuario;
        }

        public UsuarioDto MapperEntityToDto(Usuario usuario)
        {
            UsuarioDto usuarioDto = new UsuarioDto
            {
                CreatedAt = usuario.CreatedAt,
                Name = usuario.Name,
                Avatar = usuario.Avatar,
                Mail = usuario.Mail,
                DataRegistro = usuario.DataRegistro
            };

            return usuarioDto;
        }

        public IEnumerable<UsuarioDto> MapperListUsuariosDto(IEnumerable<Usuario> usuarios)
        {
            var dto = usuarios.Select(x => new UsuarioDto
            {
                Id = x.Id,
                CreatedAt = x.CreatedAt,
                Avatar = x.Avatar,
                Mail = x.Mail,
                Name = x.Name,
                DataRegistro = x.DataRegistro
            });

            return dto;
        }
    }
}
