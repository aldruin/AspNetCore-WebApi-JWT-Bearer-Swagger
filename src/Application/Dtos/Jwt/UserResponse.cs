﻿namespace CashFlowAPI.Application.Dtos.Jwt;
public sealed class UserResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string JwtToken { get; set; }
    public string Role { get; set; }
}
