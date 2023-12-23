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

        public async Task Create(ApplicationUser item)
        {
            await dbContext.AddAsync(item);
        }

        public async Task Delete(int id)
        {
          await Task.Run(async () => dbContext.Users.Remove(await Get(id)));
        }

        public async Task<ApplicationUser> Get(int id)
        {
          return await dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);    
        }

        public async Task<ApplicationUser> GetByName(string name)
        {
            return await dbContext.Users.FirstOrDefaultAsync(user => user.UserName == name);
        }

        public async Task<IEnumerable<ApplicationUser>> GetList()
        {
            return await dbContext.Users.ToArrayAsync();
        }

        public async Task Save()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(ApplicationUser item)
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
            await Save();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
