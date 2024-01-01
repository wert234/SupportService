using Microsoft.EntityFrameworkCore;
using Modules.Chat.Application.Common;
using Modules.Chat.Domain.Entitys;
using Modules.Chat.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Chat.Infrastructure.Common
{
    public class AppealRepository : IAppealRepository
    {

        private readonly AppealDbContext dbContext;

        public AppealRepository(AppealDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddMessageAsync(Message message, int appealId)
        {
            message.Appeal = await GetAsync(appealId);
            await dbContext.AddAsync(message);
        }

        public async Task CreateAsync(Appeal item)
        {
            await dbContext.AddAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Run(async () => dbContext.Remove(await GetAsync(id)));
        }

        public async Task<Appeal> GetAsync(int id)
        {
            return await dbContext.Appeals.Include("Messages").FirstOrDefaultAsync(appeal => appeal.Id == id);
        }

        public async Task<IEnumerable<Appeal>> GetListAsync()
        {
            return await dbContext.Appeals.ToArrayAsync();
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Appeal item)
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
