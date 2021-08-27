using System.Collections.Generic;
using Vector.Application.Dtos;
using Vector.Application.Interfaces;
using Vector.Application.Interfaces.Mappers;
using Vector.Domain.Core.Interfaces.Services;

namespace Vector.Application
{
    public class ApplicationServiceUsuario : IApplicationServiceUsuario
    {
        private readonly IServiceUsuario serviceUsuario;
        private readonly IMapperUsuario mapperUsuario;

        public ApplicationServiceUsuario(IServiceUsuario serviceUsuario, IMapperUsuario mapperUsuario)
        {
            this.serviceUsuario = serviceUsuario;
            this.mapperUsuario = mapperUsuario;
        }

        public void Add(UsuarioDto usuarioDto)
        {
            var usuario = mapperUsuario.MapperDtoToEntity(usuarioDto);
            serviceUsuario.Add(usuario);            
        }

        public IEnumerable<UsuarioDto> GetAll()
        {
            var usuarios = serviceUsuario.GetAll();
            
            return mapperUsuario.MapperListUsuariosDto(usuarios);
        }
    }
}
