
using CashFlowAPI.Application.Dtos;
using CashFlowAPI.Domain.Entities;

namespace CashFlowAPI.Application.Profile;
public class MapProfile : AutoMapper.Profile
{
    public MapProfile()
    {
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.Sheets, opt => opt.MapFrom(src => src.Sheets.ConvertAll(sheet => sheet.Name)));
        CreateMap<UserDto, User>();
        CreateMap<Sheet, SheetDto>();
        CreateMap<SheetDto, Sheet>();
        CreateMap<FinancialEntry, FinancialEntryDto>()
                        .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value.ToString()));
        CreateMap<FinancialEntryDto, FinancialEntry>()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => Convert.ToDecimal(src.Value)));
        CreateMap<FinancialExpense, FinancialExpenseDto>()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value.ToString()));
        CreateMap<FinancialExpenseDto, FinancialExpense>()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => Convert.ToDecimal(src.Value)));
    }
}

