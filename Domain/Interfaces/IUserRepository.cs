using CashFlowAPI.Domain.Entities;
using System.Linq.Expressions;

namespace CashFlowAPI.Domain.Interfaces;
public interface IUserRepository : IRepository<User>
{
    Task<ICollection<User>> GetAllUsers();
    Task<User> GetUserById(Guid id);
    Task<User> GetByExpressionAsync(Expression<Func<User, bool>> expression);
}