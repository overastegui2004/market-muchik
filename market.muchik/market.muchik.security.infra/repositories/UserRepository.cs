using market.muchik.security.domain.entities;
using market.muchik.security.domain.interfaces;
using market.muchik.security.infra.context;

namespace market.muchik.security.infra.repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SecurityContext context) : base(context) { }
    }
}
