using CashFlowAPI.Domain.Entities;

namespace CashFlowAPI.Domain.Interfaces;
public interface ISheetRepository : IRepository<Sheet>
{
    Task<ICollection<Sheet>> GetSheetsByUserIdAsync(Guid userId);
}