
using CashFlowAPI.Domain.ValueObjects;

namespace CashFlowAPI.Application.Sheets.Dtos;
public class SheetDto
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public Email Email { get; set; }
    public Password Password { get; set; }
    public byte[] Salt { get; set; }
}