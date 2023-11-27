using CashFlowAPI.Domain.Entities;
using CashFlowAPI.Domain.Interfaces;
using CashFlowAPI.Infrastructure.Context;
using CashFlowAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CashFlowAPI.Infrastructure.Repositories;
public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(CashFlowContext context) : base(context)
    {
    }
    public async Task<ICollection<User>> GetAllUsers()
    {
        try
        {
            //var user = await Query
            //    .Select(x => new
            //    {
            //        x.Name,
            //        x.Sheets,
            //        x.Email,
            //        x.Password,
                    
            //    }).ToListAsync();
            var usersWithSheets = await Query.Include(u => u.Sheets).ToListAsync();
            return usersWithSheets;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }
    public async Task<User> GetUserById(Guid id)
    {
        return await Query.Include(x=>x.Sheets).FirstOrDefaultAsync(x => x.Id == id);
    }
}
