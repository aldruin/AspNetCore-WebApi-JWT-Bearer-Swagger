
using CashFlowAPI.Application.Finance.Dtos;
using CashFlowAPI.Application.Sheets.Dtos;
using CashFlowAPI.Application.Users.Dtos;
using CashFlowAPI.Domain.Entities;

namespace CashFlowAPI.Application.Profile;
public class CashFlowProfile : AutoMapper.Profile
{
    public CashFlowProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        CreateMap<Sheet, SheetDto>();
        CreateMap<SheetDto, Sheet>();
        CreateMap<FinancialEntry, FinancialEntryDto>();
        CreateMap<FinancialEntryDto, FinancialEntry>();
        CreateMap<FinancialExpense, FinancialExpenseDto>();
        CreateMap<FinancialExpenseDto, FinancialExpense>();
    }
}