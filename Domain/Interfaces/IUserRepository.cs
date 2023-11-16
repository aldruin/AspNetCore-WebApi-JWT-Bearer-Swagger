using CashFlowAPI.Domain.Entities;

namespace CashFlowAPI.Domain.Interfaces;
public interface IUserRepository : IRepository<User>
{
    Task<ICollection<User>> GetAllUsers();
    Task<User> GetUserById(Guid id);
}