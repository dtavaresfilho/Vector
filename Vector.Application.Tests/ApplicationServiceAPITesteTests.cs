using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vector.Application.Dtos;
using Vector.Application.Interfaces;
using Xunit;

namespace Vector.Application.Tests
{
    public class ApplicationServiceAPITesteTests
    {
        private readonly Mock<ApplicationServiceAPITeste> applicationServiceAPITesteMock;
        private readonly ApplicationServiceAPITeste applicationServiceAPITeste;

        public ApplicationServiceAPITesteTests()
        {
            this.applicationServiceAPITesteMock = new Mock<ApplicationServiceAPITeste>();
            this.applicationServiceAPITeste = this.applicationServiceAPITesteMock.Object;
        }

        [Fact]
        public void GetAll_ReturnUsuarios()
        {
            // Arrange
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

            this.applicationServiceAPITesteMock.Setup(x => x.GetUsuarios()).Returns(listaUsuariosDto);

            // Act 
            var result = applicationServiceAPITeste.GetUsuarios();

            // Assert 
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
    }
}
