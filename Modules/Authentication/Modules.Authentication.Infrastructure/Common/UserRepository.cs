using Microsoft.EntityFrameworkCore;
using Modules.Authentication.Application.Common;
using Modules.Authentication.Domain.Entitys;
using Modules.Authentication.Infrastructure.Data;

namespace Modules.Authentication.Infrastructure.Common
{
    public class UserRepository : IUserRepository
    {

        private readonly UserDbContext dbContext;

        public UserRepository(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(ApplicationUser item)
        {
            await dbContext.AddAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
          await Task.Run(async () => dbContext.Users.Remove(await GetAsync(id)));
        }

        public async Task<ApplicationUser> GetAsync(int id)
        {
          return await dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);    
        }

        public async Task<ApplicationUser> GetByName(string name)
        {
            return await dbContext.Users.FirstOrDefaultAsync(user => user.UserName == name);
        }

        public async Task<IEnumerable<ApplicationUser>> GetListAsync()
        {
            return await dbContext.Users.ToArrayAsync();
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ApplicationUser item)
        {
            await Task.Run(() => dbContext.Update(item));
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public async void Dispose()
        {
            await SaveAsync();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
