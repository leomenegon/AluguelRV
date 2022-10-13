﻿using AluguelRV.Domain.Models;
using System.Data;

namespace AluguelRV.Domain.Dtos;
public class CreateExpenseRequest
{
    public int RentId { get; set; }
    public string Name { get; set; }
    public ExpenseType Type { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public bool? CustomDivision { get; set; }
    public IEnumerable<ExpensePersonRequest>? PersonAmount { get; set; }
}

public class ExpensePersonRequest
{
    public int PersonId { get; set; }
    public decimal? CustomAmount { get; set; }
}

public class UpdateExpenseRequest
{
    public int ExpenseId { get; set; }
    public int RentId { get; set; }
    public string Name { get; set; }
    public ExpenseType Type { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public bool? CustomDivision { get; set; }
    public IEnumerable<ExpensePersonRequest>? PersonAmount { get; set; }
}