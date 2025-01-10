﻿namespace JungleCafe.Server.ResponseModels;

public class AuthResponse
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }
}