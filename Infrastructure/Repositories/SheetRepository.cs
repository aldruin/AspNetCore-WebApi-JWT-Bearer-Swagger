using CashFlowAPI.Domain.Entities;
using CashFlowAPI.Domain.Interfaces;
using CashFlowAPI.Infrastructure.Context;
using CashFlowAPI.Infrastructure.Data;

namespace CashFlowAPI.Infrastructure.Repositories;
public class SheetRepository : Repository<Sheet>, ISheetRepository
{
    public SheetRepository(CashFlowContext context) : base(context)
    {
    }
}