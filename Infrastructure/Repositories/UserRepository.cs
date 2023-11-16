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
        return await Query.Include("Sheets").FirstOrDefaultAsync(x => x.Id == id);
    }
}