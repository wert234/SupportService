using Microsoft.EntityFrameworkCore;
using Modules.Authentication.Application.Common;
using Modules.Authentication.Domain.Entitys;
using Modules.Authentication.Infrastructure.Data;
using Shared.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            await dbContext.Users.Remove(dbContext.Users.Find(user => user.Id == id));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
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
    }
}
