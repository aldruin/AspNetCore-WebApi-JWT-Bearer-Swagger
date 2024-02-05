using CashFlowAPI.Domain.Entities;
using CashFlowAPI.Domain.ValueObjects;
using System.Text.Json.Serialization;

namespace CashFlowAPI.Application.Dtos;
public sealed class SheetDto
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public Guid UserId { get; set; }
}