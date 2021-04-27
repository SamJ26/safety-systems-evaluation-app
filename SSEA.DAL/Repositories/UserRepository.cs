using Microsoft.EntityFrameworkCore;
using SSEA.DAL.Entities;
using SSEA.DAL.Entities.Auth;
using System.Threading.Tasks;

namespace SSEA.DAL.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> GetUserNameById(int? userId)
        {
            if (userId is null || userId == 0)
                return null;
            User user = await dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
            string userName = user.FirstName + " " + user.LastName;
            return userName;
        }

        public async Task<bool> IsAuthorized<TEntity>(int userId, int itemId) where TEntity : ExtendedEntityBase
        {
            TEntity item = await dbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(i => i.Id == itemId);
            if (item is null)
                return false;
            return item.IdCreated == userId;
        }
    }
}
