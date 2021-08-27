using Vector.Domain.Core.Interfaces.Repositories;
using Vector.Domain.Entities;

namespace Vector.Infra.Data.Repositories
{
    public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario
    {
        private readonly SqlContext sqlContext;

        public RepositoryUsuario(SqlContext sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}
