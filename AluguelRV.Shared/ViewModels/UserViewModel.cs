﻿namespace AluguelRV.Shared.ViewModels;
public record UserViewModel
{
    public string? Name { get; set; }
    public string? Username { get; set; }
    public bool Resident { get; set; }
    public string? Room { get; set; }
}