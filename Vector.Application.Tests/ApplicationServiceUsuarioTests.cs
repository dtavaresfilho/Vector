using System;
using Xunit;
using Moq;
using Vector.Application.Interfaces;
using Vector.Application.Interfaces.Mappers;
using Vector.Domain.Core.Interfaces.Services;
using Vector.Domain.Entities;
using System.Collections.Generic;
using Vector.Application.Dtos;
using System.Linq;

namespace Vector.Application.Tests
{
    public class ApplicationServiceUsuarioTests
    {
        private readonly Mock<IServiceUsuario> serviceUsuarioMock;
        private readonly Mock<IMapperUsuario> mapperUsuarioMock;

        public ApplicationServiceUsuarioTests()
        {
            this.serviceUsuarioMock = new Mock<IServiceUsuario>();
            this.mapperUsuarioMock = new Mock<IMapperUsuario>();
        }

        [Fact]
        public void GetAll_ReturnUsuarios()
        {
            // Arrange
            List<Usuario> listaUsuarios = new List<Usuario>
            {
                new Usuario
                {
                    Id = 1,
                    CreatedAt = DateTime.MinValue,
                    Name = "Sam Kutch",
                    Avatar = "https://cdn.fakercloud.com/avatars/plasticine_128.jpg",
                    Mail = "Orpha.Howe@hotmail.com",
                    DataRegistro = DateTime.Today
                },
                new Usuario
                {
                    Id = 2,
                    CreatedAt = DateTime.MinValue,
                    Name = "Jean Koch",
                    Avatar = "https://cdn.fakercloud.com/avatars/plasticine_128.jpg",
                    Mail = "Morton18@gmail.com",
                    DataRegistro = DateTime.Today
                }
            };

            List<UsuarioDto> listaUsuariosDto = new List<UsuarioDto>
            {
                new UsuarioDto
                {
                    Id = 1,
                    CreatedAt = DateTime.MinValue,
                    Name = "Sam Kutch",
                    Avatar = "https://cdn.fakercloud.com/avatars/plasticine_128.jpg",
                    Mail = "Orpha.Howe@hotmail.com",
                    DataRegistro = DateTime.Today
                },
                new UsuarioDto
                {
                    Id = 2,
                    CreatedAt = DateTime.MinValue,
                    Name = "Jean Koch",
                    Avatar = "https://cdn.fakercloud.com/avatars/plasticine_128.jpg",
                    Mail = "Morton18@gmail.com",
                    DataRegistro = DateTime.Today
                }
            };

            this.serviceUsuarioMock.Setup(x => x.GetAll()).Returns(listaUsuarios);
            this.mapperUsuarioMock.Setup(x => x.MapperListUsuariosDto(It.IsAny<IEnumerable<Usuario>>())).Returns(listaUsuariosDto);

            var applicationServiceUsuario = new ApplicationServiceUsuario(serviceUsuarioMock.Object, mapperUsuarioMock.Object);

            // Act
            var result = applicationServiceUsuario.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            serviceUsuarioMock.VerifyAll();
            mapperUsuarioMock.VerifyAll();
        }
    }
}
