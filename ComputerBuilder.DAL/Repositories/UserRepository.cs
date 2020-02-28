using ComputerBuilder.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComputerBuilder.DAL.Repositories
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        private DataContext DataContext
        {
            get { return _context as DataContext; }
        }
        public UserRepository(DataContext context) : base(context)
        {

        }
    }
}
