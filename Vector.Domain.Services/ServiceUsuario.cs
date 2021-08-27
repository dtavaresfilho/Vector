using Vector.Domain.Core.Interfaces.Repositories;
using Vector.Domain.Core.Interfaces.Services;
using Vector.Domain.Entities;

namespace Vector.Domain.Services
{
    public class ServiceUsuario : ServiceBase<Usuario>, IServiceUsuario
    {
        private readonly IRepositoryUsuario repositoryUsuario;

        public ServiceUsuario(IRepositoryUsuario repositoryUsuario) : base(repositoryUsuario)
        {
            this.repositoryUsuario = repositoryUsuario;
        }
    }
}
